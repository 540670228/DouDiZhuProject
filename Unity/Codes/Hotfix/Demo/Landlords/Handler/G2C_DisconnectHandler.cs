namespace ET
{
    public class G2C_DisconnectHandler : AMHandler<G2C_Disconnect>
    {
        protected async override ETTask Run(Session session, G2C_Disconnect message)
        {
            //处理客户端下线逻辑


            await ETTask.CompletedTask;
        }
    }
}