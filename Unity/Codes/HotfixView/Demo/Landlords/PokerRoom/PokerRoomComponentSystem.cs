using UnityEditor.UI;

namespace ET
{
    public static class PokerRoomComponentSystem
    {
        //提供保存Room的方法
        public static void SetPokerRoom(this PokerRoomComponent self, PokerRoom room)
        {
            self.DeletePokerRoom();
            self.pokerRoom = room;
        }
        
        //提供注销Room的方法
        public static void DeletePokerRoom(this PokerRoomComponent self)
        {
            if (self.pokerRoom == null && self.pokerRoom.IsDisposed)
            {
                return;
            }

            UnitLComponent component = self.ZoneScene().
                    GetComponent<CurrentScenesComponent>().Scene.GetComponent<UnitLComponent>();
            //移除掉当前房间里的所有角色
            foreach (UnitL item in self.pokerRoom.unitList)
            {
                component.Remove(item.Id);
            }
            self.pokerRoom?.Dispose();
        }
    }
}