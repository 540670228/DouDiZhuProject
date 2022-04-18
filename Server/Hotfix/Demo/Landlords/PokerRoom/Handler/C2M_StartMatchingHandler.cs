using System;

namespace ET
{
    public class C2M_StartMatchingHandler : AMActorLocationRpcHandler<UnitL,C2M_StartMatching,M2C_StartMatching>
    {
        protected async override ETTask Run(UnitL unitL, C2M_StartMatching request, M2C_StartMatching response, Action reply)
        {
            //每次只能有一人进行匹配，需要进行加锁
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.MatchingLock, unitL.DomainScene().InstanceId.GetHashCode()))
            {
                try
                {
                    //申请获取一个空闲的房间
                    PokerRoom room = unitL.DomainScene().GetComponent<PokerRoomsComponent>().AllocateARoom();
                    //将玩家添加进room中
                    room.AddUnitL(unitL);
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                    throw;
                }

                reply();
            }
            
        }
    }
}