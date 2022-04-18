using System.ServiceModel.Channels;
using MongoDB.Driver.Core.Events;

namespace ET
{
    public class C2M_AddLordResultHandler : AMActorLocationHandler<UnitL,C2M_AddLordResult>
    {
        protected async override ETTask Run(UnitL unitL, C2M_AddLordResult message)
        {
            PokerRoom room = unitL.DomainScene().GetComponent<PokerRoomsComponent>().GetPokerRoom(unitL);
            //计数
            room.tmpCount++;
            //根据获取的信息 发回翻倍消息
            if (message.isAdd)
            {
                room.mutiple *= 2;
            }
            if (room.tmpCount >= 3)
            {
                //TODO：开始第一轮战斗逻辑
                foreach (UnitL item in room.unitList)
                {
                    MessageHelper.SendToClient(item,new M2C_EnterFirstRound()
                    {
                        OutId = room.lordId,
                        trueFirst = true,
                        Mutiple = room.mutiple,
                        LastId = unitL.Id,
                    });
                }
                return;
            }
            
            
            //获取下一位
            UnitL next = room.GetNextUnitL(unitL);
            foreach (UnitL item in room.unitList)
            {
                MessageHelper.SendToClient(item,new M2C_SetAddLordState()
                {
                    AddId = next.Id,
                    LastId = unitL.Id,
                    Mutiple = room.mutiple,
                    isAdd = message.isAdd,
                });
            }

            await ETTask.CompletedTask;
        }
    }
}