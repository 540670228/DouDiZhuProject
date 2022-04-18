using System.Collections.Generic;

namespace ET
{
    public class UnitL : Entity,IAwake<RoleInfo>,IDestroy
    {
        //存储角色信息
        public RoleInfo roleInfo;
        //设置角色性别
        public Sex sex;
        
        //存储角色当前拥有的牌
        public List<Poker> pokerList = new List<Poker>();

    }
}