using UnityEditor.UI;

namespace ET
{
    public class M2C_SetLordCallStateHandler : AMHandler<M2C_SetLordCallState>
    {
        protected async override ETTask Run(Session session, M2C_SetLordCallState message)
        {
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            //根据地主Id 客户端做出响应的显示
            int lordIndex = room.getUnitLIndex(message.lordId);
            
            //再DlgOperate中设置
            room.GetDlgOperate().SetCallLord(lordIndex);
            
            //显示上一个人的结果 不叫 等等
            if (message.LastId != 0)
            {
                int lastIndex = room.getUnitLIndex(message.LastId);
                room.GetDlgOperate().SetTalkInfoImage(ConstValue.callNoInfoName,lastIndex);
                Log.Warning("component!是否为空"+(session.ZoneScene().GetComponent<UnitLComponent>() == null).ToString());
                //播放不叫
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic
                                (ConstValue.Operate_NoOrder_Music + PokerRoomHelper.GetSuffix(session.ZoneScene(),message.LastId));
            }

            if (message.LastId == 0)
            {
                //播放洗牌音效
                //播放Welcome背景音乐
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Effect_Audio).PlayMusic(ConstValue.Effect_Shuff_Music);
            }
            
            
            
            await ETTask.CompletedTask;
        }
    }
}