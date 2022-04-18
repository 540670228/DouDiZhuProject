using System.Collections.Generic;

namespace ET
{
    public class UnitLAwakeSystem: AwakeSystem<UnitL,RoleInfo>
    {
        public override void Awake(UnitL self, RoleInfo roleInfo)
        {
            self.roleInfo = roleInfo;
            self.sex = roleInfo.getSex();
        }
    }
    
    public static class UnitLSystem
    {
        //添加扑克
        public static void AddPokerList(this UnitL self,List<Poker> pokerList)
        {
            self.pokerList.Clear();
            self.pokerList = pokerList;
        }

        public static void AddPoker(this UnitL self, Poker poker)
        {
            self.pokerList.Add(poker);
        }
    }
}