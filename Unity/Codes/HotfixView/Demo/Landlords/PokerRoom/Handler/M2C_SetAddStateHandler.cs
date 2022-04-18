using UnityEditor.UI;

namespace ET
{
    public class M2C_SetAddStateHandler : AMHandler<M2C_SetAddState>
    {
        protected async override ETTask Run(Session session, M2C_SetAddState message)
        {
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            
            //亮明底牌 加入玩家手牌
            session.ZoneScene().GetComponent<PokerViewsComponent>().SetKeepPokerView(room.keepList);
            
            //如果自己是地主 才将牌加入
            if (session.ZoneScene().GetComponent<MyUnitLComponent>().unitL.Id == message.AddId)
            {
                session.ZoneScene().GetComponent<PokerViewsComponent>().InsertKeepPokerView(room.keepList);
            }
            //显示地主图标
            room.GetDlgRoom().SetLord(room.getUnitLIndex(message.AddId));
            
            //更新地主Id
            room.lordId = message.AddId;
            
            //根据是否翻倍判断是否抢了地主
            bool isRob = room.mutiple != message.Mutiple;

            //更新房间倍数UI
            room.mutiple = message.Mutiple;
            room.RefreshRoomInfo();
            
            //更新加倍按钮组
            int addIndex = room.getUnitLIndex(message.AddId);
            room.GetDlgOperate().SetAddLord(addIndex);
            
            //更新地主的牌数量
            room.GetDlgOperate().SetBackCount(addIndex,20);

            string str = isRob? ConstValue.Operate_Rob_Music : ConstValue.Operate_NoRob_Music;
            str += PokerRoomHelper.GetSuffix(session.ZoneScene(), message.LastId);
            session.ZoneScene().GetComponent<AudiosComponent>().
                    GetAudio(AudioType.Operate_Audio).PlayMusic(str);


            await ETTask.CompletedTask;
        }
    }
}