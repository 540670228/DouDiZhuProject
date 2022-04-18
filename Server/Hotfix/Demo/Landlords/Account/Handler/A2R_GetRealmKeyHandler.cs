using System;

namespace ET
{
    public class A2R_GetRealmKeyHandler : AMActorRpcHandler<Scene, A2R_GetRealmKey, R2A_GetRealmKey>
    {
        protected async override ETTask Run(Scene scene, A2R_GetRealmKey request, R2A_GetRealmKey response, Action reply)
        {
            //验证服务器类型
            if (!VerifyHelper.VerifySceneType(scene, SceneType.Realm, response, reply))
                return;
            
            //生成RealmKey
            string realmKey = VerifyHelper.GenerateRandomToken();

            //存储到Realm网关Scene的TokenComponent组件上
            //先移除老的key - Token
            scene.GetComponent<TokenComponent>().Remove(request.AccountId);
            scene.GetComponent<TokenComponent>().Add(request.AccountId, realmKey);
            response.RealmKey = realmKey;
            reply();

            await ETTask.CompletedTask;
        }
    }
}