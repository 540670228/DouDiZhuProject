using System.Collections.Generic;

namespace ET
{
    public class PokerRoomsComponent:Entity,IAwake
    {
        public List<PokerRoom> roomList = new List<PokerRoom>();
    }
}