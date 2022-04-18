namespace ET
{
    [MessageHandler]
    public class M2C_CreateUnitLHandler : AMHandler<M2C_CreateUnitL>
    {
        protected override async ETTask Run(Session session, M2C_CreateUnitL message)
        {
            // 通知场景切换协程继续往下走
            session.DomainScene().GetComponent<ObjectWait>().Notify(new WaitType.Wait_CreateUnitL() {Message = message});
            await ETTask.CompletedTask;
        }
    }
}