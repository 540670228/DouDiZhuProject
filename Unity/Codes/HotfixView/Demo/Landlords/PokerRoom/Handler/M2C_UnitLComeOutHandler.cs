using UnityEditor.UI;

namespace ET
{
    public class M2C_UnitLComeOutHandler : AMHandler<M2C_UnitLComeOut>
    {
        protected async override ETTask Run(Session session, M2C_UnitLComeOut message)
        {
            if (!message.isRes)
            {
                //有玩家退出，根据UnitL Id移除
                PokerRoom room =  session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
                //根据Id查询索引位置
                int index = room.getUnitLIndex(message.UnitLId);
                room.RemoveUnitL(index);
            }
            //移除UnitL在UnitLComponent下
            session.ZoneScene().GetComponent<CurrentScenesComponent>().Scene.GetComponent<UnitLComponent>().Remove(message.UnitLId);
            await ETTask.CompletedTask;
        }
    }
}