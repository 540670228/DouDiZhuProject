using UnityEditor.UI;

namespace ET
{
    public class M2C_ResultInfoHandler : AMHandler<M2C_ResultInfo>
    {
        protected async override ETTask Run(Session session, M2C_ResultInfo message)
        {
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            //显示结算界面
            session.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Result);
            DlgResult dlgRes = session.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgResult>();
            dlgRes.SetResultInfo(message.resultList,message.winId);
            
            //播放胜利或失败的背景音乐
            bool isWin = session.ZoneScene().GetComponent<MyUnitLComponent>().unitL.Id == message.winId;
            string musicName = isWin? ConstValue.BK_Win_Music : ConstValue.BK_Lose_Music;
            session.ZoneScene().GetComponent<AudiosComponent>().
                    GetAudio(AudioType.BackGround_Audio).PlayMusic(musicName);
                
            
            await ETTask.CompletedTask;
        }
    }
}