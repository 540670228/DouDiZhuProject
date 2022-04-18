using System;

namespace ET
{
    public class C2A_GetRealmKeyHandler: AMRpcHandler<C2A_GetRealmKey, A2C_GetRealmKey>
    {
        protected async override ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response, Action reply)
        {
            //向Realm服务器发送请求，为客户端分配一个网关服务器
            //验证服务器
            if (!VerifyHelper.VerifySceneType(session.DomainScene(), SceneType.Account, response, reply))
            {
                session?.DisConnect().Coroutine();
                return;
            }

            //判断登录令牌
            if (!VerifyHelper.VerifyTheToken(session, request.AccountId, request.Token, response, reply))
                return;

            //防止请求频繁
            if (!VerifyHelper.VerifyReaptedRequest(session, response, reply))
            {
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                //防止在此期间玩家被顶号下线
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountId.GetHashCode()))
                {
                    //每个区服都有一个Realm网关
                    StartSceneConfig startSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);

                    R2A_GetRealmKey r2A_GetRealmKey = null;

                    try
                    {
                        r2A_GetRealmKey =
                                await MessageHelper.CallActor(startSceneConfig.InstanceId,
                                    new A2R_GetRealmKey() { AccountId = request.AccountId, }) as R2A_GetRealmKey;


                    }
                    catch (Exception e)
                    {
                        Log.Error(e.ToString());
                    }


                    if (r2A_GetRealmKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = r2A_GetRealmKey.Error;
                        reply();
                        session?.DisConnect().Coroutine();
                    }

                    //发送回客户端
                    response.RealmKey = r2A_GetRealmKey.RealmKey;
                    //获取当前区服下 realm网关的外网端口，后续客户端可直接与Realm相连
                    response.RealmAddress = startSceneConfig.OuterIPPort.ToString();
                    reply();
                    //然后可以断开连接了
                    session?.DisConnect().Coroutine();

                }
            }
        }
    }
}