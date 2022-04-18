using System.ServiceModel.Channels;
using MongoDB.Driver.Core.Events;

namespace ET
{
    public class C2M_FightInfoHandler : AMActorLocationHandler<UnitL,C2M_FightInfo>
    {
        protected async override ETTask Run(UnitL unitL, C2M_FightInfo message)
        {
            PokerRoom room = unitL.DomainScene().GetComponent<PokerRoomsComponent>().GetPokerRoom(unitL);
            //判断是否出牌
            if (message.isOut)
            {
                //计数器记录地主出过几次牌 判断春天用
                room.tmpCount += unitL.Id == room.lordId? 1 : 0;
                room.tmpCount2 = 0;
                //0. 更新牌列表，倍数，判断是否游戏结束
                foreach (PokerProto proto in message.pokerList)
                {
                    unitL.pokerList.RemoveById(proto.PokerId);
                }

                if (message.PokerListType == (int) PokerListType.NormalBoom ||
                    message.PokerListType == (int) PokerListType.BigBoom)
                {
                    room.mutiple *= 2;
                }

                if (unitL.pokerList.Count == 0)
                {
                    //判断春天  地主：农民均剩17张牌  农民：地主只出过第一次牌
                    if (unitL.Id != room.lordId && room.tmpCount == 1)
                        room.mutiple *= 2;
                    if (unitL.Id == room.lordId)
                    {
                        bool flag = true;
                        foreach (var u in room.unitList)
                        {
                            if (u.pokerList.Count != 0 && u.pokerList.Count != 17) flag = false;
                        }

                        if (flag) room.mutiple *= 2;
                    }

                    //TODO:进行结算逻辑 对金币等进行结算 通知给客户端
                    room.SetResultInfo(unitL);
                    
                    //TODO:通知完客户端 将客户端下所有其它玩家踢出房间
                    foreach (var item in room.unitList)
                    {
                        foreach (var tmp in room.unitList)
                        {
                            if(tmp == item) continue;
                            MessageHelper.SendToClient(item,new M2C_UnitLComeOut()
                            {
                                UnitLId = tmp.Id,
                                isRes = true,
                            });
                        }
                    }
                    room.InitRoom();
                    
                }
            }
            else room.tmpCount2++;

            //计数不出的个数，如果不出2次 下一个开启的就是第一轮 而不是普通轮
            if (room.tmpCount2 == 2)
            {
                room.tmpCount2 = 0;
                //下个玩家
                UnitL nextPlayer = room.GetNextUnitL(unitL);
                
                foreach (UnitL item in room.unitList)
                {
                    MessageHelper.SendToClient(item,new M2C_EnterFirstRound()
                    {
                        trueFirst = false,
                        OutId = nextPlayer.Id,
                        LastId = unitL.Id,
                    });
                }
                return;
            }
            
            //1. 告知其余玩家打的什么牌
            
            //2. 通知客户端 牌数 倍数 进行更新
            
            //3. 通知下家打牌
            UnitL next = room.GetNextUnitL(unitL);

            foreach (UnitL item in room.unitList)
            {
                MessageHelper.SendToClient(item,new M2C_FightInfo()
                {
                    mutiple = room.mutiple,
                    LastId = unitL.Id,
                    nextId = next.Id,
                    pokerList = message.pokerList,
                    PokerListType = message.PokerListType,
                    LastCount = unitL.pokerList.Count,
                    isOut = message.isOut,
                });
            }

            await ETTask.CompletedTask;
        }
    }
}