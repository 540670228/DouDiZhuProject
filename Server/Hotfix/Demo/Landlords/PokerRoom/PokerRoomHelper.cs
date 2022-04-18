using System.Collections.Generic;

namespace ET
{
    public static class PokerRoomHelper
    {
        public static RoomInfo CreateRoomInfo(PokerRoom pokerRoom)
        {
            return new RoomInfo()
            {
                RoomId = pokerRoom.Id,
                RoomState = (int) pokerRoom.state, 
                BasicScore = ConstValue.basicScore,
                mutiple = ConstValue.basicMutiple,
            };
        }
        
        public static List<PokerProto> CreateProtoList(List<Poker> pokerList)
        {
            List<PokerProto> protoList = new List<PokerProto>();
            foreach (Poker poker in pokerList)
            {
                protoList.Add(poker.ToMessage());
            }

            return protoList;
        }

        
    }
}