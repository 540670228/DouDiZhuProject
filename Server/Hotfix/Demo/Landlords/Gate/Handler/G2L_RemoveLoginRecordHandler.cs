using System;

namespace ET.Demo.Landlords.Gate.Handler
{
    public class G2L_RemoveLoginRecordHandler : AMActorRpcHandler<Scene,G2L_RemoveLoginRecord,L2G_RemoveLoginRecord>
    {
        protected async override ETTask Run(Scene scene, G2L_RemoveLoginRecord request, L2G_RemoveLoginRecord response, Action reply)
        {
            //移除当前账户Id
            AccountLoginRecordComponent component = scene.GetComponent<AccountLoginRecordComponent>();
            component.Remove(request.AccountId);
            Log.Warning("移除LoginCenter记录");
            reply();
            await ETTask.CompletedTask;
        }
    }
}