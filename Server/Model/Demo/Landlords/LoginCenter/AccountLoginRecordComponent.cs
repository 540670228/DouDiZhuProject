using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 账户登录记录组件，记录账号登录到的网关
    /// </summary>
    public class AccountLoginRecordComponent:Entity,IAwake, IDestroy
    {
        //存储账户Id 和其所在的区服zone号
        public Dictionary<long,int> AccountLoginInfoDic = new Dictionary<long,int>();
    }
}