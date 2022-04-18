namespace ET
{

    public class Poker : Entity,IAwake<PokerType,PokerValue>,IDestroy,IAwake
    {
        //扑克牌的花色类型
        public PokerType pokerType;

        //扑克牌的点数
        public PokerValue pokerValue;

        //扑克牌名称和Resource资源名对应
        public string pokerName;

    }
    
    public enum PokerType
    {
        None = 0,   //无花色
        Square = 1, //方块
        Club = 2,   //梅花
        Heart = 3,  //红桃
        Spade = 4,  //黑桃
    }

    public enum PokerValue
    {
        None  = 0,
        Three = 3,
        Four  = 4,
        Five  = 5,
        Six   = 6,
        Seven = 7,
        Eight = 8,
        Nine  = 9,
        Ten   = 10,
        Jack  = 11, //J
        Queen = 12, //Q
        King  = 13, //K
        One   = 14,
        Two   = 15,
        SJoker= 16, //smallJoker
        LJoker= 17, //LargeJoker

    }
    
    //定义牌的组合类型
    public enum PokerListType
    {
        None = 0,
        Single = 1, //单张
        Pair = 2,   //一对
        
        ThreeWithZero = 3, //三张不带
        ThreeWithOne = 4, //三带一
        ThreeWithPair = 5, //三代一对
        

        StraightOne = 6,  //顺子 34567
        StraightPair = 7, //连对 334455
        
        PlaneWithZero = 8, //飞机不带
        PlaneWithOne = 9,  //飞机带两单张
        PlaneWithPair = 10, //飞机带两对
        
        FourWithOne = 11,   //四带2单张
        FourWithPair = 12,  //四带2对

        NormalBoom = 13, //普通炸弹
        BigBoom = 14,  //王炸
    }
}