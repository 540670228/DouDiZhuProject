using System;

namespace ET.Demo.Account.Handler
{
    public class C2G_LoginGameGateHandler : AMRpcHandler<C2G_LoginGameGate, G2C_LoginGameGate>
    {
        protected async override ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response, Action reply)
        {
            //验证服务器
            if (!VerifyHelper.VerifySceneType(session.DomainScene(), SceneType.Gate, response, reply))
            {
                session?.DisConnect().Coroutine();
                return;
            }

            //避免请求繁忙
            if (!VerifyHelper.VerifyReaptedRequest(session,response,reply))
            {
                return;
            }

            //验证Token
            if (!VerifyHelper.VerifyTheToken(session, request.AccountId, request.GateKey, response, reply))
            {
                return;
            }

            //移除Token
            session.DomainScene().GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
            //移除验证组件 否则5s后会断开
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, request.AccountId.GetHashCode()))
                {
                    Log.Warning("开始登录网关");
                    //防止多个客户端同时访问此逻辑
                    if (instanceId != session.InstanceId)
                        return;

                    //通知登录中心服务器 记录本次登录的服务器Zone
                    StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenterConfig;

                    //发送消息 ServerId 直接用网关的区服号即可
                    L2G_AddLoginRecord l2G_AddLoginRecord = await MessageHelper.CallActor(loginCenterConfig.InstanceId, new G2L_AddLoginRecord()
                    {
                        AccountId = request.AccountId,
                        ServerId = session.DomainScene().Zone,
                    }) as L2G_AddLoginRecord;
                    if (l2G_AddLoginRecord.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = l2G_AddLoginRecord.Error;
                        reply();
                        session?.DisConnect().Coroutine();
                        return;
                    }

                    Log.Warning("L2G消息发送完成");
                    

                    Log.Warning("Session组件添加完成");
                    

                    //将信息添加进登陆中心成功后 进行映射Player的创建，以后就可以通过Actor之间发消息了
                    Player player = session.DomainScene().GetComponent<PlayerComponent>().Get(request.AccountId);
                    
                    Log.Warning("是否有Player可以复用 + " + (player != null));

                    //如果player为空则进行创建 不为空则说明成功 移除组件
                    if (player == null)
                    {
                        Log.Warning("角色开始创建");
                        
                        //创建一个Player 网关下与客户端的映射 第一个参数是实体Id 这里直接使用AccountId
                        player = session.DomainScene().GetComponent<PlayerComponent>().
                            AddChildWithId<Player, long, long>(request.RoleId, request.AccountId,0);
                        player.playerState = PlayerState.Gate;
                        Log.Warning("角色创建成功");
                        //将Player加入到组件中缓存起来
                        session.DomainScene().GetComponent<PlayerComponent>().Add(player);
                        Log.Warning("角色加入组件集合成功");

                        //为Session增加MailBox组件使得此Session连接称为有处理Actor消息的能力的实体
                        session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);

                        Log.Debug("Player添加完成");
                    }
                    else
                    {
                        //非顶号操作都会是重新创建Player和Unit映射实体，顶号时（前后上下线不超过10s）会进行复用
                        //角色顶号登录，必须移除此组件 ，此组件Awake后10s后会将玩家踢下线
                        player.RemoveComponent<PlayerOffLineOutTimeComponent>();
                        Log.Debug("移除角色下线组件成功");
                    }

                    //SessionPlayerComponent保存在Session上缓存了Player相关，和Player一一对应
                    session.AddComponent<SessionPlayerComponent>().PlayerInstanceId = player.InstanceId;
                    //也要更新PlayerId
                    session.GetComponent<SessionPlayerComponent>().PlayerId = player.Id;
                    player.SessionInstanceId = session.InstanceId;
                    
                    response.PlayerId = player.Id;
                    reply();

                    Log.Warning("登录网关成功");

                }


                await ETTask.CompletedTask;
            }
        }
    }
}