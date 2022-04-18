using System;
using System.Collections.Generic;

namespace ET
{
    public class C2A_CreateRoleHandler : AMRpcHandler<C2A_CreateRole, A2C_CreateRole>
    {
        protected async override ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response, Action reply)
        {
            //验证服务器
            if (!VerifyHelper.VerifySceneType(session.DomainScene(), SceneType.Account,response,reply))
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
            
            //防止连续多次请求创建角色，解决请求过于频繁的问题
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.RoleInfoLock, request.AccountId))
                {
                    //查询数据库中是否已经有此角色  必须角色名和区服号serverId均相等
                    List<RoleInfo> roleInfos = await DBManagerComponent.Instance.
                        GetZoneDB(session.DomainZone()).Query<RoleInfo>(d => d.Name == request.Name);
                    //判断是否有重复名称
                    if (roleInfos != null && roleInfos.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        reply();
                        return;
                    }
                    
                    //必须使用GenerateUnitId将角色Entity.Id赋值  参数为区服号
                    RoleInfo newRoleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    //初始化新建的角色信息
                    newRoleInfo.Name = request.Name;
                    newRoleInfo.AccountId = request.AccountId;
                    newRoleInfo.HeadSpriteName = request.headName;
                    newRoleInfo.PhotoSpriteName = request.charName;
                    newRoleInfo.goldCount = 0;
                    newRoleInfo.diamond = 0;
                    newRoleInfo.CreateTime = TimeHelper.ServerNow();
                    newRoleInfo.LastLoginTime = 0;

                    await DBManagerComponent.Instance.GetZoneDB(request.ServerId).Save<RoleInfo>(newRoleInfo);
                    
                    
                    //将创建好的roleInfo传回客户端
                    response.RoleInfo = newRoleInfo.ToMessage();

                    reply();

                    newRoleInfo?.Dispose();
                }
            }
        }
    }
}