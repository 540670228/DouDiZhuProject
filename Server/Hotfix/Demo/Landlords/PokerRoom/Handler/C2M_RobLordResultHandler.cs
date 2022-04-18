using System.ServiceModel.Channels;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Core.Operations;

namespace ET
{
    public class C2M_RobLordResultHandler : AMActorLocationHandler<UnitL,C2M_RobLordResult>
    {
        protected async override ETTask Run(UnitL unitL, C2M_RobLordResult message)
        {
            PokerRoom room = unitL.DomainScene().GetComponent<PokerRoomsComponent>().GetPokerRoom(unitL);
            if (message.isRob)
            {
                //暂时的新地主
                room.lordId = unitL.Id;
                //翻倍
                room.mutiple *= 2;
            }
            
            //计数器
            room.tmpCount++;
            if (room.tmpCount == 2)
            {
                //如果两次都没抢 直接开始
                if (room.lordId == room.callId)
                {
                    room.tmpCount = 0;
                    //增加地主的手牌
                    foreach (Poker poker in room.keepList)
                    {
                        room.GetUnitL(room.lordId).pokerList.Add(poker);
                    }
                    //TODO:开始加倍逻辑
                    foreach (UnitL item in room.unitList)
                    {
                        MessageHelper.SendToClient(item,new M2C_SetAddState()
                        {
                            AddId = room.lordId,
                            Mutiple = room.mutiple,
                            LastId = unitL.Id,
                        });
                    }
                    
                    return;
                }
            }
            else if (room.tmpCount >= 3)
            {
                //TODO:开始加倍逻辑
                room.tmpCount = 0;
                foreach (UnitL item in room.unitList)
                {
                    MessageHelper.SendToClient(item,new M2C_SetAddState()
                    {
                        AddId = room.lordId,
                        Mutiple = room.mutiple,
                        LastId = unitL.Id,
                    });
                }
                return;
            }
            

            
            //发送消息
            UnitL next = room.GetNextUnitL(unitL);
            foreach (UnitL item in room.unitList)
            {
                MessageHelper.SendToClient(item,new M2C_SetLordRobState()
                {
                    isFirst = false,
                    isRob = message.isRob,
                    LastId = unitL.Id,
                    robId = next.Id,
                    Mutiple = room.mutiple,
                });
            }


            await ETTask.CompletedTask;
        }
    }
}