namespace ET
{
    public enum PokerViewState
    {
        Normal = 1,
        Prepare = 2,
    }
    public class PokerView : Entity,IAwake,IDestroy
    {
        public Poker poker;

        public PokerViewState state;

    }
}