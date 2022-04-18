namespace ET
{
    public class M2C_NewUnitLComeInHandler:AMHandler<M2C_NewUnitLComeIn>
    {
        protected async override ETTask Run(Session session, M2C_NewUnitLComeIn message)
        {
            //接收到信息将新角色 加入到客户端房间中
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            UnitL newUnitL = UnitLFactory.Create(session.ZoneScene().GetComponent<CurrentScenesComponent>().Scene,
                message.unitLInfo);
            int len = room.unitList.Count;
            Log.Warning("增加新角色："+newUnitL.roleInfo.Name + "索引为:"+len);
            room.AddUnitL(newUnitL,len);
            
            await ETTask.CompletedTask;
        }
    }
}