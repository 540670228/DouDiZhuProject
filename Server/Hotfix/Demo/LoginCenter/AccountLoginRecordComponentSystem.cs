namespace ET
{
    //销毁时释放字典
    public class AccountLoginRecordComponentDestroySystem : DestroySystem<AccountLoginRecordComponent>
    {
        public override void Destroy(AccountLoginRecordComponent self)
        {
            self.AccountLoginInfoDic.Clear();
        }
    }

    /// <summary>
    /// 提供账户记录字典的增删改查
    /// </summary>
    public static class AccountLoginRecordComponentSystem
    {
        
        public static void Add(this AccountLoginRecordComponent self,long key,int value)
        {
            if(self.AccountLoginInfoDic.ContainsKey(key))
            {
                self.AccountLoginInfoDic[key] = value;
                return;
            }
            self.AccountLoginInfoDic.Add(key,value);
        }

        public static void Remove(this AccountLoginRecordComponent self,long key)
        {
            if(self.AccountLoginInfoDic.ContainsKey(key))
                self.AccountLoginInfoDic.Remove(key);
        }

        public static int Get(this AccountLoginRecordComponent self,long key)
        {
            if(self.AccountLoginInfoDic.ContainsKey(key)) 
                return self.AccountLoginInfoDic[key];
            return -1;
        }

        public static bool IsExists(this AccountLoginRecordComponent self,long key)
        {
            return self.AccountLoginInfoDic.ContainsKey(key);
        }
    }
}