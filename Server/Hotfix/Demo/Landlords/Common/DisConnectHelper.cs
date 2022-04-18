using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class DisConnectHelper
    {
        public async static ETTask DisConnect(this Session self)
        {
            if (self == null || self.IsDisposed)
                return;

            long instanceId = self.InstanceId;

            await TimerComponent.Instance.WaitAsync(1000);

            //等待1s过程中session可能会因其他逻辑提前释放，这步是用来判断此种情况的
            //判断安全状态
            if (self.InstanceId != instanceId)
            {
                return;
            }
            self.Dispose();
        }
        
        public async static ETTask KickPlayer(Player player, bool isException = false)
        {
            Log.Warning("角色踢下线！"+player.UnitId);
            
            if(player == null || player.IsDisposed)
            {
                return ;
            }

            long instanceId = player.InstanceId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,player.AccountId.GetHashCode()))
            {
                //一个角色可能会请求下线多次，在第一次下线后player会Dispose并且InstanceId=0会不同 后续请求直接返回不在进行
                if(player.IsDisposed || instanceId != player.InstanceId)
                {
                    return;
                }

                if(!isException)
                {
                    switch (player.playerState)
                    {
                        case PlayerState.DisConnect:
                            break;
                        case PlayerState.Gate:
                            break;
                        case PlayerState.Game:
                            
                            //TODO 通知游戏逻辑服下线Unit角色，并将数据存入数据库
                            Log.Warning("通知游戏逻辑服下线");
                            M2G_RequestExitGame m2G_RequestExitGame = await 
                                MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestExitGame()) as M2G_RequestExitGame;

                            //向登陆中心发送消息，移除当前player
                            long loginCenterConfigSceneId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;
                            L2G_RemoveLoginRecord l2G_RemoveLoginRecord = await MessageHelper.CallActor(loginCenterConfigSceneId
                                , new G2L_RemoveLoginRecord()
                                {
                                    AccountId = player.AccountId, 
                                    ServerId = player.DomainZone()
                                }) as L2G_RemoveLoginRecord;
                            
                            break;
                    }
                }

                player.playerState = PlayerState.DisConnect;
                //从网关服务器上移除Player
                player.DomainScene().GetComponent<PlayerComponent>()?.Remove(player.AccountId);
                player?.Dispose();
                Log.Warning("KickPlayer + Player释放掉");
                //防止player组件有异步释放逻辑 等待0.3s
                await TimerComponent.Instance.WaitAsync(300);
                
            }
        }
    }
}
