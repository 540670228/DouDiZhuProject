using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace ET
{
    public class PokerRoomAwakeSystem:AwakeSystem<PokerRoom>
    {
        public override void Awake(PokerRoom self)
        {
            self.state = (int)RoomState.Matching;
            self.mutiple = ConstValue.basicMutiple;
            self.basicScore = ConstValue.basicScore;
        }
    }

    //服务端的房间逻辑
    public static class PokerRoomSystem
    {
        public static bool isRelax(this PokerRoom self)
        {
            return self.state == (int)RoomState.Matching;
        }
        
        //根据unitLId获取当前房间下的unitL
        public static UnitL GetUnitL(this PokerRoom self, long id)
        {
            return self.unitList.Find(d => d.Id == id);
        }
        
        //游戏玩家进入
        public static void AddUnitL(this PokerRoom self, UnitL unitL)
        {
            Log.Warning("房间号:"+self.Id+"房间当前人数："+self.unitList.Count);
            //在进行匹配操作时加锁，防止一次性涌入过多玩家
            //1. 获取已经进入此房间玩家的信息并通知其它玩家
            List<UnitLInfo> infoList = new List<UnitLInfo>(); //存储已经在房间的玩家信息
            M2C_NewUnitLComeIn m2CNewUnitLComeIn = new M2C_NewUnitLComeIn()
            {
                unitLInfo = new UnitLInfo() { UnitLId = unitL.Id, RoleInfoProto = unitL.roleInfo.ToMessage() }
            };
            try
            {
                foreach (UnitL item in self.unitList)
                {
                    //通知已经在房间的玩家
                    MessageHelper.SendToClient(item,m2CNewUnitLComeIn);
                    //存储信息
                    infoList.Add(new UnitLInfo()
                    {
                        UnitLId = item.Id,
                        RoleInfoProto = item.roleInfo.ToMessage(),
                    });
                }

                //2. 将房间信息发回给客户端
                M2C_RoomUnitLInfo m2CRoomUnitLInfo = new M2C_RoomUnitLInfo()
                {
                    infoList = infoList,
                    roomInfo = PokerRoomHelper.CreateRoomInfo(self),
                };
                MessageHelper.SendToClient(unitL,m2CRoomUnitLInfo);

                //3. 加入列表，判断是否需要切换满员状态
                self.unitList.Add(unitL);
                if (self.unitList.Count >= 3)
                {
                    self.EnterGamingState();
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            
        }
        //游戏玩家退出
        public static void RemoveUnitL(this PokerRoom self, UnitL unitL,bool isUnexpected = false)
        {
            //Matching下的移除和Gaming下不同
            if (self.state == (int)RoomState.Matching)
            {
                Log.Warning("移除服务端请求下线的UnitL!!!");
                //移除出房间的玩家列表
                self.unitList.Remove(unitL);
                
                foreach (UnitL item in self.unitList)
                {
                    if (isUnexpected && item.Id == unitL.Id) continue;
                    MessageHelper.SendToClient(item,new M2C_UnitLComeOut()
                    {
                        UnitLId = unitL.Id
                    });
                }
            }
            else if (self.state == (int) RoomState.Game)
            {
                
            }
            
            
            

        }
        
        //选择当前玩家的下一个玩家
        public static UnitL GetNextUnitL(this PokerRoom self, UnitL unitL)
        {
            int index = self.unitList.IndexOf(unitL);
            index = (index + 1) % 3;
            return self.unitList[index];
        }

        public static void InitRoom(this PokerRoom self)
        {
            
            //更新计数器
            self.tmpCount = 0;
            self.tmpCount2 = 0;
            //清空三个玩家的牌库和底牌
            foreach (var item in self.unitList)
            {
                item.pokerList.Clear();
            }
            self.keepList.Clear();
            self.mutiple = ConstValue.basicMutiple;
            self.basicScore = ConstValue.basicMutiple;
            self.state = (int)RoomState.Matching;

            //移除所有玩家
            self.unitList.Clear();
            
        }
        public static void EnterGamingState(this PokerRoom self)
        {
            self.state = (int)RoomState.Game;
            //创建随机一副牌
            self.CreateRandomPoker();
            //分发给三个玩家
            self.DistributePokerToPlayer();
            //将三个牌的列表发给三个玩家
            foreach (UnitL unitL in self.unitList)
            {
                MessageHelper.SendToClient(unitL,new M2C_EnterGamingState()
                {
                    PokerProtoList = PokerRoomHelper.CreateProtoList(unitL.pokerList),
                    keepPokerProtoList = PokerRoomHelper.CreateProtoList(self.keepList),
                });
            }
            //随机选择一个地主 向客户端发送结果
            Random random = new Random();
            int index = random.Next(0, 3);

            foreach (UnitL unitL in self.unitList)
            {
                MessageHelper.SendToClient(unitL,new M2C_SetLordCallState()
                {
                    lordId = self.unitList[index].Id,
                });
            }
        }

        public static void CreateRandomPoker(this PokerRoom self)
        {
            //创建一副新牌
            List<Poker> pokers = new List<Poker>();

            //第一次创建实体  后续直接复用
            if (self.pokerIdList.Count == 0)
            {
                //创建普通牌 4 * 13
                for (int tp = (int) PokerType.Square; tp <= (int) PokerType.Spade; tp++)
                {
                    for (int val = (int) PokerValue.Three; val <= (int) PokerValue.Two; val++)
                    {
                        Poker poker = self.AddChild<Poker, PokerType, PokerValue>((PokerType) tp, (PokerValue) val);
                        pokers.Add(poker);
                        self.pokerIdList.Add(poker.Id);
                    }
                }

                //创建大小王
                Poker sJoker = self.AddChild<Poker, PokerType, PokerValue>(PokerType.None, PokerValue.SJoker);
                Poker lJoker = self.AddChild<Poker, PokerType, PokerValue>(PokerType.None, PokerValue.LJoker);
                pokers.Add(sJoker);
                pokers.Add(lJoker);
                self.pokerIdList.Add(sJoker.Id);
                self.pokerIdList.Add(lJoker.Id);
            }
            else
            {
                foreach (long id in self.pokerIdList)
                {
                    pokers.Add(self.GetChild<Poker>(id));
                }
            }
            

            self.pokerList.Clear();
            Random rand = new Random();
            //顺序打乱放到PokerList中 将顺序的牌随机插入到pokerList当中去
            foreach (Poker poker in pokers)
            {
                //左闭右开
                int index = rand.Next(0, self.pokerList.Count + 1);
                //插入到pokerList中
                self.pokerList.Insert(index,poker);
            }
        }

        public static void DistributePokerToPlayer(this PokerRoom self)
        {
            //清空UnitL下的扑克
            foreach (UnitL player in self.unitList)
            {
                player.pokerList.Clear();
            }
            //清空底牌
            self.keepList.Clear();
            //分发给3个玩家 和 留三张底牌
            for (int i = 0; i < self.pokerList.Count; i++)
            {
                if (i < 17)
                {
                    self.unitList[0].AddPoker(self.pokerList[i]);
                }
                else if (i < 34)
                {
                    self.unitList[1].AddPoker(self.pokerList[i]);
                }
                else if (i < 51)
                {
                    self.unitList[2].AddPoker(self.pokerList[i]);
                }
                else
                {
                    self.keepList.Add(self.pokerList[i]);
                }
            }
            //将三个玩家的牌都进行排序
            foreach (UnitL player in self.unitList)
            {
                Log.Warning("向"+player.Id+"发送几张牌"+player.pokerList.Count);
                PokerListTypeHelper.SortPoker(player.pokerList);
            }
            
        }

        public static void SetResultInfo(this PokerRoom self,UnitL winUnitL)
        {
            int deltaCount = self.mutiple * self.basicScore;
            //赢家加金币
            if (winUnitL.Id == self.lordId)
                winUnitL.roleInfo.goldCount += deltaCount * 2;
            else winUnitL.roleInfo.goldCount += deltaCount;
            //输家减金币
            foreach (var item in self.unitList)
            {
                if(item.Id == winUnitL.Id) continue;
                if (item.Id == self.lordId)
                    item.roleInfo.goldCount -= deltaCount * 2;
                else item.roleInfo.goldCount -= deltaCount;
            }
            //写入数据库中
            foreach (var item in self.unitList)
            {
                DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save<RoleInfo>(item.roleInfo).Coroutine();
            }

            List<ResultInfo> resList = new List<ResultInfo>();
            foreach (var item in self.unitList)
            {
                int deltaGold = deltaCount;
                if (item.Id == self.lordId) deltaGold *= 2;
                if (item.Id != winUnitL.Id) deltaGold *= -1;
                resList.Add(new ResultInfo()
                {
                    UnitLId = item.Id,
                    deltaGold = deltaGold,
                    name = item.roleInfo.Name,
                });
            }
            //发送消息通知客户端
            foreach (var item in self.unitList)
            {
                MessageHelper.SendToClient(item,new M2C_ResultInfo()
                {
                    resultList = resList,
                    winId = winUnitL.Id,
                });
            }
            
        }
    }
}