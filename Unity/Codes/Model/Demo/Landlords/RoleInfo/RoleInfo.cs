namespace ET
{
    public enum Sex
    {
        boy,girl
    }
    public class RoleInfo:Entity,IAwake
    {
        //名称
        public string Name;
        //所属账号ID
        public long AccountId;
        //头像名称
        public string HeadSpriteName;
        //人物形象名称
        public string PhotoSpriteName;
        //账户金币
        public int goldCount;
        //账户砖石
        public int diamond;
        //上次登录时间
        public long LastLoginTime;
        //创建时间
        public long CreateTime;
    }
}