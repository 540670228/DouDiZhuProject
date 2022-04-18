using System.Collections.Generic;
using System.Net.Http;

namespace ET
{
    public enum RoomState
    {
        //正在匹配
        Matching = 1,
        //进入游戏
        Game = 2,
    }
    public class PokerRoom : Entity,IAwake,IDestroy
    {
        //房间Id号 直接用实体的Id
        //玩家列表
        public List<UnitL> unitList = new List<UnitL>();
        //房间状态
        public int state;
        //计数器
        public int tmpCount = 0;
        public int tmpCount2 = 0;
        //叫地主的Id
        public long callId = 0;
        //地主Id
        public long lordId = 0;
        
        //底分
        public int basicScore = 100;
        //倍数
        public int mutiple = 1;
        
        //一副牌
        public List<Poker> pokerList = new List<Poker>();
        //底牌
        public List<Poker> keepList = new List<Poker>();
        
        //缓存牌的Id
        public List<long> pokerIdList = new List<long>();

    }
}