using UnityEngine.UIElements;

namespace ET
{
    public class M2C_EnterMatchingStateHandler: AMHandler<M2C_EnterMatchingState>
    {
        protected async override ETTask Run(Session session, M2C_EnterMatchingState message)
        {
            
            
            await ETTask.CompletedTask;
        }
    }
}