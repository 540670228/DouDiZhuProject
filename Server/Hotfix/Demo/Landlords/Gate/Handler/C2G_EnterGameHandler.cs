using System;
using MongoDB.Driver.Core.Events;

namespace ET
{
    public class C2G_EnterGameHandler : AMRpcHandler<C2G_EnterGame, G2C_EnterGame>
    {
        protected async override ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response, Action reply)
        {
            //验证服务器
            if(!VerifyHelper.VerifySceneType(session.DomainScene(),SceneType.Gate,response,reply))
            {
                session?.DisConnect();
                return;
            }

            if (!VerifyHelper.VerifyReaptedRequest(session,response,reply))
            {
                return;
            }

            //获取SessionPlayer映射组件
            SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if(sessionPlayerComponent == null)
            {
                response.Error = ErrorCode.ERR_SessionPlayerIsNull;
                reply();
                return;
            }

            //根据组件的InstanceId 拿到相应的Player
            Player player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
            if(player == null || player.IsDisposed)
            {
                response.Error = ErrorCode.ERR_NonePlayerError;
                reply();
                return;
            }

            RoleInfo roleInfo = session.AddChild<RoleInfo>();
            roleInfo.FromMessage(request.roleInfoProto);
            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,player.AccountId.GetHashCode()))
                {
                    //有可能一次多个请求，剩余请求在外面阻塞，当第一个进行完下面条件就不会满足 后续进来直接退出即可
                    if(instanceId != session.InstanceId || player.IsDisposed)
                    {
                        return;
                    }
                    
                    //SessionState作用目前还不得而知？？

                    Log.Warning("Player的状态为"+player.playerState.ToString());
                    //当player已经是Game状态 即复用了Player 即顶号情况下 考虑是否能复用Unit 无缝衔接
                    if(player.playerState == PlayerState.Game)
                    {
                        try
                        {
                            //利用player身上保存的unitId进行传输ActorLocation消息 会由Location定位服务器得到InstanceId
                            Log.Warning("UnitId+"+player.UnitId);
                            IActorResponse reqEnter = await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestEnterGameState());
                            //若仍能正常收发消息 说明可以复用 直接返回UnitID
                            if(reqEnter.Error == ErrorCode.ERR_Success)
                            {
                                Log.Warning("顶号复用成功！");
                                //发回复用的UnitId
                                response.MyId = player.UnitId;
                                reply();
                                return;
                            }
                            Log.Error("二次登录失败 "+ reqEnter.Error + " | " + reqEnter.Message);
                            
                            //二次登录失败 释放连接 踢下线相关映射对象
                            response.Error = reqEnter.Error;
                            //第二个参数为true是因为Exception踢下线 因为没创建出Unit无需踢Unit下线
                            await DisConnectHelper.KickPlayer(player, true);
                            reply();
                            session?.DisConnect().Coroutine();


                        }
                        catch(Exception e)
                        {
                            Log.Error("二次登录失败  " + e.ToString());
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisConnectHelper.KickPlayer(player, true);
                            reply();
                            session?.DisConnect().Coroutine();
                            throw;
                        }
                        return;
                    }


                    //当Player对象处于Normal状态时 不在Game下
                    try
                    {
                        //可能unit只能在map游戏服务器间传送，暂时创建一个map服务器用于传送？

                        //为Player增加GateMap组件 其中包含一个Scene属性
                        GateMapComponent gateMapComponent =  player.AddComponent<GateMapComponent>();
                        //在gateMapComponent下创建一个Map类型的Scene并赋值给属性
                        gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateLobby", SceneType.Lobby);
                        
                        //在scene下获取UnitComponent并在组件下创建unit实体 实体Id和player保持一致
                        UnitL unitL = UnitLFactory.Create(
                            gateMapComponent.Scene, player.Id,roleInfo);
                        //为Unit添加Gate组件保存 Gate到客户端的连接
                        unitL.AddComponent<UnitGateComponent, long>(session.InstanceId);
                        
                        //unit存储在游戏逻辑服上面 通过sessionInstanceId可以向客户端发送消息
                        StartSceneConfig startScene = StartSceneConfigCategory.Instance.
                                GetBySceneName(session.DomainZone(), ConstValue.LobbySceneName);
                        //将unit传送到map中 指定scene的InstanceId和name
                        await TransferSceneHelper.Transfer(unitL, startScene.InstanceId, startScene.Name);
                        Log.Warning("UnitL成功传送到Lobby服务器");
                        //更新player的UnitId
                        player.UnitId = unitL.Id;
                        //更新组件
                        session.GetComponent<SessionPlayerComponent>().PlayerId = unitL.Id;
                        //更新PlayerSessionComponent
                        response.MyId = unitL.Id;

                        reply();

                        //改变PlayerState 为游戏状态
                        //Player是客户端在网关上的映射对象 Unit是客户端在游戏服务器上的映射对象
                        player.playerState = PlayerState.Game;

                    }
                    catch (Exception e)
                    {
                        Log.Error($"角色进入逻辑服出现问题 账号Id：{player.AccountId}  角色Id : {player.Id} 异常信息：{e.ToString()}");
                        response.Error = ErrorCode.ERR_EnterGameError;
                        reply();
                        //由于异常下线不做对游戏对象的处理
                        await DisConnectHelper.KickPlayer(player,true);
                        session?.DisConnect().Coroutine();
                    }
                }
            }

        }
    }
}