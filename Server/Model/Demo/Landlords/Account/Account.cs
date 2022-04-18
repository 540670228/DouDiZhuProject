namespace ET
{
    public enum AccountType
    {
        //正常用户
        Normal = 0,
        //黑名单用户
        BlackList = 1,
    }

    public class Account : Entity,IAwake
    {
        public string AccountName;  //账户名

        public string PassWord;     //账户密码

        public long CreateTime;     //账号创建时间

        public int AccountType;     //账号类型
    }
}