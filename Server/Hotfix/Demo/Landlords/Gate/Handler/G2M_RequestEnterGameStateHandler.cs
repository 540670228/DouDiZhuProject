using System;
using System.Collections.Specialized;

namespace ET
{
    public class G2M_RequestEnterGameStateHandler : AMActorLocationRpcHandler<UnitL,G2M_RequestEnterGameState,M2G_RequestEnterGameState>
    {
        protected async override ETTask Run(UnitL unitL, G2M_RequestEnterGameState request, M2G_RequestEnterGameState response, Action reply)
        {
            //测试是否能正常通信所用，直接返回即可
            reply();
            await ETTask.CompletedTask;
        }
    }
}