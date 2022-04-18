using System;

namespace ET
{
    public class AccountInfoComponentDestroySystem : DestroySystem<AccountInfoComponent>
    {
        public override void Destroy(AccountInfoComponent self)
        {
            self.Token = null;
            self.AccountId = 0;
        }
    }

    public static class AccountInfoComponentSystem
    {
        
    }
}