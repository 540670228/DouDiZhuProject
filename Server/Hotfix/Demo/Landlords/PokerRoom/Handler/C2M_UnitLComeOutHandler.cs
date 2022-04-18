namespace ET
{
    public class C2M_UnitLComeOutHandler: AMActorLocationHandler<UnitL,C2M_UnitLComeOut>
    {
        protected async override ETTask Run(UnitL unitL, C2M_UnitLComeOut message)
        {
            //将此UnitL移除 并 通知同一房间其它unit下线消息
            PokerRoom room = 
                    unitL.DomainScene().GetComponent<PokerRoomsComponent>().GetPokerRoom(unitL);
            
            room.RemoveUnitL(unitL);

            await ETTask.CompletedTask;
        }
    }
}