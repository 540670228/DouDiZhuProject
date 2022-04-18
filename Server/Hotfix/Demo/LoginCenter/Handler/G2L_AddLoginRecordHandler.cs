using System;

namespace ET
{
    public class G2L_AddLoginRecordHandler : AMActorRpcHandler<Scene, G2L_AddLoginRecord, L2G_AddLoginRecord>
    {
        protected async override ETTask Run(Scene scene, G2L_AddLoginRecord request, L2G_AddLoginRecord response, Action reply)
        {
            //验证服务器
            if (!VerifyHelper.VerifySceneType(scene, SceneType.LoginCenter, response, reply))
                return;

            //由于在顶号操作时有异步顶号踢下线的操作，这里防止冲突也要加锁
            using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock,request.AccountId.GetHashCode()))
            {
                //更新角色所在的区服信息
                scene.GetComponent<AccountLoginRecordComponent>().Remove(request.AccountId);
                scene.GetComponent<AccountLoginRecordComponent>().Add(request.AccountId, request.ServerId);
            }
            reply();

            await ETTask.CompletedTask;
        }
    }
}