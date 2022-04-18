namespace ET
{
    public static class UnitLFactory
    {
        public static UnitL Create(Scene scene, UnitLInfo info)
        {
            UnitLComponent unitLComponent = scene.GetComponent<UnitLComponent>();
            
            RoleInfo roleInfo = unitLComponent.AddChild<RoleInfo>();
            roleInfo.FromMessage(info.RoleInfoProto);
            //如果已经有了则删除
            unitLComponent.Remove(info.UnitLId);
            //创建客户端下unitL对象
            UnitL unitL = unitLComponent.AddChildWithId<UnitL, RoleInfo>(info.UnitLId, roleInfo);
            return unitL;
        }
    }
}