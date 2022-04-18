using System;

namespace ET
{
    public class R2G_GetLoginGateKeyHandler : AMActorRpcHandler<Scene, R2G_GetLoginGateKey, G2R_GetLoginGateKey>
    {
        protected async override ETTask Run(Scene scene, R2G_GetLoginGateKey request, G2R_GetLoginGateKey response, Action reply)
        {
            //验证服务器
            if(!VerifyHelper.VerifySceneType(scene,SceneType.Gate,response,reply))
            {
                return;
            }

            //生成验证key
            string GateKey = VerifyHelper.GenerateRandomToken();
            //保存前先移除
            scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
            //将key保存到网关服务器的组件中
            scene.GetComponent<GateSessionKeyComponent>().Add(request.AccountId, GateKey);
            response.GateSessionKey = GateKey;
            reply();

            await ETTask.CompletedTask;
        }
    }
}