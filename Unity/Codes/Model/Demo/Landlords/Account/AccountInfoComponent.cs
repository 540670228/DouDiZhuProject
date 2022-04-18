namespace ET
{
    public class AccountInfoComponent:Entity,IAwake,IDestroy
    {
        //账号服务器令牌
        public string Token;
        //账户Id
        public long AccountId;
        //Realm网关令牌
        public string RealmKey;
        //Realm网关地址
        public string RealmAddress;
    }
}