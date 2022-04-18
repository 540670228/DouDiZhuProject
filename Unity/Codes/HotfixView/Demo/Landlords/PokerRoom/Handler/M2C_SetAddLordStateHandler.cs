using UnityEditor.UI;

namespace ET
{
    public class M2C_SetAddLordStateHandler : AMHandler<M2C_SetAddLordState>
    {
        protected async override ETTask Run(Session session, M2C_SetAddLordState message)
        {
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            
            //设置Info信息
            int lastIndex = room.getUnitLIndex(message.LastId);
            string tmp = message.isAdd? ConstValue.addYesInfoName : ConstValue.addNoInfoName;
            room.GetDlgOperate().SetTalkInfoImage(tmp,lastIndex);
            //更新Mutiple
            room.mutiple = message.Mutiple;
            room.RefreshRoomInfo();

            //设置Add按钮组
            int addIndex = room.getUnitLIndex(message.AddId);
            room.GetDlgOperate().SetAddLord(addIndex);

            //播放加倍音效
            string str = message.isAdd? ConstValue.Operate_jiabei_Music : ConstValue.Operate_noJiaBei_Music;
            str += PokerRoomHelper.GetSuffix(session.ZoneScene(), message.LastId);
            session.ZoneScene().GetComponent<AudiosComponent>().
                    GetAudio(AudioType.Operate_Audio).PlayMusic(str);
            
            await ETTask.CompletedTask;
        }
    }
}