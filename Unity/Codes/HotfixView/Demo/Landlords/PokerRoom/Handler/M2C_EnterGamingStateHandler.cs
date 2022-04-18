using System.Collections.Generic;

namespace ET
{
    public class M2C_EnterGamingStateHandler : AMHandler<M2C_EnterGamingState>
    {
        protected async override ETTask Run(Session session, M2C_EnterGamingState message)
        {
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            //将牌保存到unitL中？ 有必要吗
            //session.ZoneScene().GetComponent<MyUnitLComponent>().unitL.AddPokerList(PokerRoomHelper.GetPokerList(room,message.PokerProtoList));
            
            //显示DlgOperate
            session.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Operate);
            
            //回收上局残留的所有实体 并 清空所有列表 刷新UI等等
            session.ZoneScene().GetComponent<PokerViewsComponent>().PrepareGame();
            //对自己进行发牌
            session.ZoneScene().GetComponent<PokerViewsComponent>().SetMyPokerView(PokerRoomHelper.GetPokerList(room,message.PokerProtoList));
            
            //将底牌缓存到room中 后续使用
            room.keepList = PokerRoomHelper.GetPokerList(room, message.keepPokerProtoList);

            await ETTask.CompletedTask;
        }
    }
}