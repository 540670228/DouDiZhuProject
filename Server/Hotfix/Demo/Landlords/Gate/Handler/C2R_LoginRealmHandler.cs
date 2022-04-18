using System;

namespace ET
{
    public class C2R_LoginRealmHandler : AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response, Action reply)
        {
            Log.Warning("成功连接Realm网关服务器，开始进行处理");
            //验证服务器
            if(!VerifyHelper.VerifySceneType(session.DomainScene(),SceneType.Realm,response,reply))
            {
                session?.DisConnect().Coroutine();
                return;
            }

            //验证令牌
            if(!VerifyHelper.VerifyTheToken(session,request.AccountId,request.RealmKey,response,reply))
            {
                return;
            }

            //验证请求繁忙
            if(!VerifyHelper.VerifyReaptedRequest(session,response,reply))
            {
                return;
            }
            Log.Warning("验证Realm成功");
            //验证通过后移除令牌 -- 后续不会再连接Realm网关服务器
            session.DomainScene().GetComponent<TokenComponent>().Remove(request.AccountId);

            using(session.AddComponent<SessionLockingComponent>())
            {
                using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginRealm,request.AccountId))
                {
                    //固定分配一个Gate 此账号Id会固定分配到此网关服务器下
                    StartSceneConfig config = RealmGateAddressHelper.GetGate(session.DomainZone(),request.AccountId);

                    //向gate请求一个key，客户端通过此key连接gate
                    G2R_GetLoginGateKey g2R_GetLoginGateKey = await MessageHelper.CallActor(config.InstanceId,new R2G_GetLoginGateKey()
                    {
                        AccountId = request.AccountId,
                    }) as G2R_GetLoginGateKey;

                    if(g2R_GetLoginGateKey.Error != ErrorCode.ERR_Success)
                    {
                        Log.Error(g2R_GetLoginGateKey.Error.ToString());
                        session.DisConnect().Coroutine();
                        return;
                    }
                    
                    //将网关地址和令牌发回客户端
                    response.GateSessionKey = g2R_GetLoginGateKey.GateSessionKey;
                    response.GateAddress = config.OuterIPPort.ToString();
                    Log.Warning("分配网关成功，将信息返回给客户端");
                    reply();

                }
            }
        }
    }
}
