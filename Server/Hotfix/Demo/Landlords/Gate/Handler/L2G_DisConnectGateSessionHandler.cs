using System;

namespace ET
{
    public class L2G_DisConnectGateSessionHandler : AMActorRpcHandler<Scene,L2G_DisConnectGateSession,G2L_DisConnectGateSession>
    {
        protected async override ETTask Run(Scene scene, L2G_DisConnectGateSession request, G2L_DisConnectGateSession response, Action reply)
        {
            //验证服务器类型
            if (!VerifyHelper.VerifySceneType(scene, SceneType.Gate, response, reply))
                return;

            long accountId = request.AccountId;
            
            //获取玩家实体 Player
            Player player = scene.GetComponent<PlayerComponent>().Get(accountId);
            
            //如果玩家已经被释放 直接返回即可
            if (player == null || player.IsDisposed)
            {
                reply();
                return;
            }
            
            //获取gateSession
            Session gateSession = Game.EventSystem.Get(player.SessionInstanceId) as Session;

            if (gateSession != null && !gateSession.IsDisposed)
            {
                //向客户端发送下线消息  SUCCESS是主动下线，OtherAccountLogin为顶号下线
                gateSession.Send(new G2C_Disconnect(){Error = ErrorCode.ERR_OtherAccountLogin});
                gateSession.DisConnect().Coroutine();
                Log.Warning("gateSession释放成功");
            }
            //将Player的Session置0  后续登录者只需更新Session相关即可
            player.AccountId = 0; 
            Log.Warning("为Player添加下线组件！！");
            //添加下线组件 即如果顶号者 10s内仍未连接到网关就KickPlayer 踢Unit
            player.AddComponent<PlayerOffLineOutTimeComponent>();

            reply();

            await ETTask.CompletedTask;
        }
    }
}