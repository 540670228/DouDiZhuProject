using UnityEditor.UI;

namespace ET
{
    public class M2C_SetLordRobStateHandler : AMHandler<M2C_SetLordRobState>
    {
        protected async override ETTask Run(Session session, M2C_SetLordRobState message)
        {
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            
            //设置TalkInfo
            if (message.isFirst)
            {
                int lastIndex = room.getUnitLIndex(message.LastId);
                room.GetDlgOperate().SetTalkInfoImage(ConstValue.callYesInfoName,lastIndex);
                //播放叫地主音效
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).
                        PlayMusic(ConstValue.Operate_Order_Music+PokerRoomHelper.GetSuffix(session.ZoneScene(),message.LastId));
            }
            else
            {
                int lastIndex = room.getUnitLIndex(message.LastId);
                string tmp = message.isRob? ConstValue.robYesInfoName : ConstValue.robNoInfoName;
                //更新room的倍数信息
                room.mutiple = message.Mutiple;
                room.RefreshRoomInfo();
                room.GetDlgOperate().SetTalkInfoImage(tmp,lastIndex);
                
                //播放音效
                string str = message.isRob? ConstValue.Operate_Rob_Music : ConstValue.Operate_NoRob_Music;
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic(str + PokerRoomHelper.GetSuffix(session.ZoneScene(),message.LastId));
            }
            
            //设置按钮组
            int index = room.getUnitLIndex(message.robId);
            
            room.GetDlgOperate().SetRobLord(index);
            
            await ETTask.CompletedTask;
        }
    }
}