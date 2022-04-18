namespace ET
{
    public class C2M_CallLordResultHandler : AMActorLocationHandler<UnitL,C2M_CallLordResult>
    {
        protected async override ETTask Run(UnitL unitL, C2M_CallLordResult message)
        {
            PokerRoom room = unitL.DomainScene().GetComponent<PokerRoomsComponent>().GetPokerRoom(unitL);
            if (room == null)
            {
                //强制下线可能造成room为空
                return;
            }

            //根据叫地主结果判断  如果结果为true通知所有玩家进入下一阶段 结果为false下一个玩家进行叫地主
            if (message.isCall == false)
            {
                //房间计数器+1
                room.tmpCount++;
                if (room.tmpCount >= 3)
                {
                    //重新洗牌 重新开始
                    room.EnterGamingState();
                    room.tmpCount = 0;
                }
                //获取下一个unitL
                UnitL next = room.GetNextUnitL(unitL);
                //向三个客户端发送消息
                foreach(UnitL item in room.unitList)
                {
                    MessageHelper.SendToClient(item,new M2C_SetLordCallState()
                    {
                        lordId = next.Id,
                        LastId = unitL.Id,
                    });
                }
            }
            else
            {
                //抢地主阶段 每人一次机会 每抢一次 倍数翻倍 最终结果以最后一个抢的为准
                //通知所有玩家到下一阶段  抢地主阶段
                room.tmpCount = 0;
                room.lordId = unitL.Id;
                room.callId = unitL.Id;
                //获取下一个玩家
                UnitL next = room.GetNextUnitL(unitL);
                //发送包含 叫地主方和下一个
                foreach (UnitL item in room.unitList)
                {
                    //没有指定上一方LastId默认为叫地主一方
                    MessageHelper.SendToClient(item,new M2C_SetLordRobState()
                    {
                        robId = next.Id,
                        LastId = unitL.Id,
                        isFirst = true,
                    });
                }
            }

            await ETTask.CompletedTask;
        }
    }
}