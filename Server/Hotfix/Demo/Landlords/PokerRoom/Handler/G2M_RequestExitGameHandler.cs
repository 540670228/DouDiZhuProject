using System;
using System.ServiceModel.Channels;
using MongoDB.Driver.Core.Events;

namespace ET
{
    public class G2M_RequestExitGameHandler : AMActorLocationRpcHandler<UnitL,G2M_RequestExitGame,M2G_RequestExitGame>
    {
        protected async override ETTask Run(UnitL unitL, G2M_RequestExitGame request, M2G_RequestExitGame response, Action reply)
        {
            try
            {
                //意外下线 需要通知当前房间其它玩家进行返回
                PokerRoom room = unitL.DomainScene().GetComponent<PokerRoomsComponent>().GetPokerRoom(unitL);
                if (room == null)
                {
                    //强制下线可能造成空
                    reply();
                    return;
                }
                if (room.state == (int) RoomState.Matching)
                {
                    //Matching期间意外掉线 直接发送下线流程即可
                    room.RemoveUnitL(unitL,true);
                    reply();
                    return;
                }
            
                //初始化房间
                //TODO:通知完客户端 将客户端下所有其它玩家踢出房间

                foreach (UnitL item in room.unitList)
                {
                    if(item.Id == unitL.Id) continue;
                    //发送房间意外掉线信息
                    MessageHelper.SendToClient(item,new M2C_UnexpectedDisconnect()
                    {
                        name = unitL.roleInfo.Name,
                    });
                }
            
                room.InitRoom();
            
            
                //销毁UnitL对象
                await unitL.RemoveLocation();
                UnitLComponent unitLComponent = unitL.DomainScene().GetComponent<UnitLComponent>();
                unitLComponent.Remove(unitL.Id);
                
                unitL?.Dispose();
                Log.Warning("释放unitL对象");
                reply();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                reply();
                throw;
            }
        }
    }
}