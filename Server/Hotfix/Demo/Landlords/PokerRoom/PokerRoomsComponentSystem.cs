using MongoDB.Driver.Core.Events;

namespace ET
{
    public class  PokerRoomsComponentAwakeSystem : AwakeSystem<PokerRoomsComponent>
    {
        public override void Awake(PokerRoomsComponent self)
        {
            
        }
    }

    public static class PokerRoomsComponentSystem
    {
        public static PokerRoom CreatePokerRoom(this PokerRoomsComponent self)
        {
            PokerRoom room = self.AddChildWithId<PokerRoom>(IdGenerater.Instance.GenerateUnitId(1));
            //如果Room有高倍场 高分场等等 这里应该添加类型 根据类型创建 当前就直接写死了
            return room;
        }

        public static PokerRoom AllocateARoom(this PokerRoomsComponent self)
        {
            //分配还有位置的空闲房间给用户
            PokerRoom room = null;
            foreach (PokerRoom item in self.roomList)
            {
                if (item.isRelax())
                {
                    room = item;
                    break;
                }
            }

            if(room == null) room = self.CreatePokerRoom();
            self.roomList.Add(room);

            return room;
        }

        public static PokerRoom GetPokerRoom(this PokerRoomsComponent self, UnitL unitL)
        {
            return self.roomList.Find((room) => room.unitList.Find((d) => d.Id == unitL.Id) != null);
        }
        
    }
}