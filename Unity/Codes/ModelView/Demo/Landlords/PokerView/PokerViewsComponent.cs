using System.Collections.Generic;

namespace ET
{
    public class PokerViewsComponent:Entity,IAwake,IDestroy
    {
        //缓存所有pokerView
        public List<PokerView> pokerViewList = new List<PokerView>();
        
        //存放自身的pokerView
        public List<PokerView> selfPokerViewList = new List<PokerView>();
        
        //存放当前选中的pokerView
        public List<PokerView> selectPokerViewList = new List<PokerView>();
        

        public List<PokerView> player0OutPokerList = new List<PokerView>();
        public List<PokerView> player1OutPokerList = new List<PokerView>();
        public List<PokerView> player2OutPokerList = new List<PokerView>();
        
    }
}