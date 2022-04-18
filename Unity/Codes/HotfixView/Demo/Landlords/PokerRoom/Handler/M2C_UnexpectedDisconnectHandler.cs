using System.Linq;

namespace ET
{
    public class M2C_UnexpectedDisconnectHandler : AMHandler<M2C_UnexpectedDisconnect>
    {
        protected async override ETTask Run(Session session, M2C_UnexpectedDisconnect message)
        {
            //直接关闭room和operate窗口回到主界面即可
            session.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Room);
				
            session.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Operate);
            
            session.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgFade>().StartFade(WindowID.WindowID_Result,WindowID.WindowID_LandlordsLobby);

            UnitLComponent component = session.ZoneScene().GetComponent<UnitLComponent>();
            
            //销毁其它角色客户端下的UnitL
            long MyUnitId = session.ZoneScene().GetComponent<MyUnitLComponent>().unitL.Id;
            /*
            foreach (var item in component.Children.Values.ToArray())
            {
                if(item.Id == MyUnitId) continue;
                item?.Dispose();
            }*/

            //等待2s后提示玩家下线消息
            await TimerComponent.Instance.WaitAsync(2000);
            
            //提示玩家有下线消息
            session.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLandlordsLobby>().View.ESTipsUI.
                    ShowTips("有玩家中途退出，您已回到大厅界面！");
            
            await ETTask.CompletedTask;
        }
    }
}