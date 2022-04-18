namespace ET
{
    public class M2C_EnterFirstRoundHandler : AMHandler<M2C_EnterFirstRound>
    {
        protected async override ETTask Run(Session session, M2C_EnterFirstRound message)
        {
            //开启第一轮战斗逻辑 地主先出牌
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;

            bool isAdd = room.mutiple != message.Mutiple;
            
            if (message.Mutiple != 0)
            {
                room.mutiple = message.Mutiple;
                room.RefreshRoomInfo();
            }

            //设置第一轮牌
            int outIndex = room.getUnitLIndex(message.OutId);
            room.GetDlgOperate().SetFirstRound(outIndex);

            if (message.trueFirst)
            {
                //为自己的牌添加交互
                session.ZoneScene().GetComponent<PokerViewsComponent>().SetPokerViewInteraction();
                //如果倍数不一致说明加倍了 放音效
                string str = isAdd? ConstValue.Operate_jiabei_Music : ConstValue.Operate_noJiaBei_Music;
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic(
                            str + PokerRoomHelper.GetSuffix(session.ZoneScene(),message.LastId));
            }
            else
            {
                //如果不是第一轮说明上家不要
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic(
                            ConstValue.Operate_buyao_Music + PokerRoomHelper.GetSuffix(session.ZoneScene(),message.LastId));
            }
            
            

            await ETTask.CompletedTask;
        }
    }
}