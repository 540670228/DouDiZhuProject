using System;

namespace ET
{
    public class C2M_TestHandler : AMActorLocationRpcHandler<UnitL,C2M_Test,M2C_Test>
    {
        protected async override ETTask Run(UnitL unitL, C2M_Test request, M2C_Test response, Action reply)
        {
            Log.Warning("游戏服务器成功收到测试消息...");
            reply();
            await ETTask.CompletedTask;
        }
    }
}