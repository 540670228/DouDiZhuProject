using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    //定时器处理函数
    [Timer(TimerType.PlayerOffLineOutTime)]
    public class PlayerOfflineOutTime: ATimer<PlayerOffLineOutTimeComponent>
    {
        public override void Run(PlayerOffLineOutTimeComponent self)
        {
            try
            {
                self.KickPlayer();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    public class PlayerOfflineOutTimeComponentAwakeSystem : AwakeSystem<PlayerOffLineOutTimeComponent>
    {
        public override void Awake(PlayerOffLineOutTimeComponent self)
        {
            //10s 之后执行
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 10000, TimerType.PlayerOffLineOutTime, self);
        }
    }

    public class PlayerOfflineOutTimeComponentDestroySystem : DestroySystem<PlayerOffLineOutTimeComponent>
    {
        public override void Destroy(PlayerOffLineOutTimeComponent self)
        {
            //移除自身的计时器
            TimerComponent.Instance.Remove(ref self.Timer);
            Log.Warning("移除player的下线计时器");
        }
    }


    public static class PlayerOfflineOutTimeComponentSystem
    {
        public static void KickPlayer(this PlayerOffLineOutTimeComponent self)
        {
            Log.Warning("角色下线组件生效，开始下线");
            DisConnectHelper.KickPlayer(self.GetParent<Player>()).Coroutine();
        }
    }
}