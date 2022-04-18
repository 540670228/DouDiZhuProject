using System;
using System.Linq;

namespace ET
{
    public class UnitLComponentAwakeSystem: AwakeSystem<UnitLComponent>
    {
        public override void Awake(UnitLComponent self)
        {
        }
    }
    
    public class UnitLComponentDestroySystem: DestroySystem<UnitLComponent>
    {
        public override void Destroy(UnitLComponent self)
        {
            Log.Debug("客户端的UnitLComponent被销毁");
        }
    }
    
    public static class UnitLComponentSystem
    {
        public static void Add(this UnitLComponent self, UnitL unitL)
        {
            
        }

        public static UnitL Get(this UnitLComponent self, long id)
        {
            UnitL unit = self.GetChild<UnitL>(id);
            return unit;
        }

        public static void Remove(this UnitLComponent self, long id)
        {
            UnitL unit = self.GetChild<UnitL>(id);
            unit?.Dispose();
        }
        

    }
}