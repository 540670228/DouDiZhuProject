using System;
namespace ET
{
    public class A2L_RobGateSessionHandler : AMActorRpcHandler<Scene,A2L_RobGateSession,L2A_RobGateSession>
    {
        protected async override ETTask Run(Scene scene, A2L_RobGateSession request, L2A_RobGateSession response, Action reply)
        {
            //验证服务器
            if (!VerifyHelper.VerifySceneType(scene, SceneType.LoginCenter, response, reply))
                return;

            long accountId = request.AccountId;
            
            //使用协程锁 防止同时多次请求顶号的逻辑错误
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountId.GetHashCode()))
            {
                //判断账户是否已经登录 若未登录直接返回即可
                if (!scene.GetComponent<AccountLoginRecordComponent>().IsExists(accountId))
                {
                    reply();
                    return;
                }
                //取出登录的区服号 -- 在斗地主项目中其实只有一个服务器 id 1
                int zone = scene.GetComponent<AccountLoginRecordComponent>().Get(accountId);
                
                //AccountId和区服号 唯一确定一个网关服务器 ， 内部利用取模实现
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone,accountId);
                
                Log.Warning("开始向Gate网关发送下线消息...");
                
                //LoginCenter向Gate发送的下线消息一般为顶号操作 无需KickPlayer 而是复用Player和Unit
                L2G_DisConnectGateSession l2G_DisConnectGateSession = new L2G_DisConnectGateSession() { AccountId = accountId, };
                G2L_DisConnectGateSession g2L_DisConnectGateSession = null;

                try
                {
                    //向网关服务器发送消息
                    g2L_DisConnectGateSession = await MessageHelper.
                            CallActor(gateConfig.InstanceId,l2G_DisConnectGateSession) as G2L_DisConnectGateSession;

                    //判断错误码
                    if (g2L_DisConnectGateSession.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = g2L_DisConnectGateSession.Error;
                        reply();
                        Log.Error(response.Error.ToString());
                        return;
                    }
                    
                }
                catch (Exception e)
                {
                    response.Error = ErrorCode.ERR_NetWorkError;
                    reply();
                    Log.Error(e.ToString());
                }

                response.Error = ErrorCode.ERR_Success;
                reply();
                Log.Warning("网关服务器已成功下线！");
            }
        }
    }
}