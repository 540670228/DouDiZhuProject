using System;

namespace ET
{
    public class C2A_GetRoleHandler : AMRpcHandler<C2A_GetRole,A2C_GetRole>
    {
        protected async override ETTask Run(Session session, C2A_GetRole request, A2C_GetRole response, Action reply)
        {
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
            if (!VerifyHelper.VerifyReaptedRequest(session,response,reply))
            {
                return;
            }

            long accountId = request.AccountId;

            using (session.AddComponent<SessionLockingComponent>())
            {
                using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.RoleInfoLock,request.AccountId))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<RoleInfo>(
                        d => d.AccountId == accountId
                    ) ;

                    if(roleInfos == null || roleInfos.Count==0)
                    {
                        reply();
                        return;
                    }
                    
                    Log.Warning("缓存RoleInfo成功");
                    
                    response.RoleInfo = roleInfos[0].ToMessage();
                    reply();
                    
                    
                }
            }
        }
    }
}