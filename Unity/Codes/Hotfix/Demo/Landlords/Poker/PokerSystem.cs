namespace ET
{
    public class PokerAwakeSystem : AwakeSystem<Poker,PokerType,PokerValue>
    {
        public override void Awake(Poker self, PokerType type, PokerValue value)
        {
            self.pokerType = type;
            self.pokerValue = value;
            //大小王没有花色
            if (type == PokerType.None) self.pokerName = value.ToString();
            else  self.pokerName = type.ToString() + value.ToString();
           
        }
    }
    
    public static class PokerSystem
    {
        //Proto相互转换
        public static PokerProto ToMessage(this Poker self)
        {
            return new PokerProto() {
                PokerId = self.Id,
                pokerName = self.pokerName, 
                PokerType = (int) self.pokerType, 
                PokerValue = (int) self.pokerValue, };
        }

        public static void FromMessage(this Poker self, PokerProto proto)
        {
            //self.Id = proto.PokerId; 创建的时候解决
            self.pokerName = proto.pokerName;
            self.pokerType = (PokerType)proto.PokerType;
            self.pokerValue = (PokerValue) proto.PokerValue;
        }
    }
}