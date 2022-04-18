namespace ET
{
    public class M2C_RoomUnitLInfoHandler : AMHandler<M2C_RoomUnitLInfo>
    {
        protected async override ETTask Run(Session session, M2C_RoomUnitLInfo message)
        {
            //创建房间信息
            PokerRoom room =  PokerRoomHelper.CreatePokerRoom(session.ZoneScene(), message.roomInfo);
            //加载自身信息
            room.AddUnitL(session.ZoneScene().GetComponent<MyUnitLComponent>().unitL,0);
            int index = room.unitList.Count;
            //加载其它玩家信息
            foreach (UnitLInfo info in message.infoList)
            {
                //在CurrentScene下加载unitL
                UnitL unitL = UnitLFactory.Create(session.ZoneScene().GetComponent<CurrentScenesComponent>().Scene, info);
                room.AddUnitL(unitL,index++);
            }
            
            //刷新room信息
            room.RefreshRoomInfo();

            await ETTask.CompletedTask;
        }
    }
}