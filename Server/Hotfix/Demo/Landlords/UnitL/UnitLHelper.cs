namespace ET
{
    public static class UnitLHelper
    {
        public static UnitLInfo CreateUnitLInfo(UnitL unitL)
        {
            UnitLInfo info = new UnitLInfo();
            info.UnitLId = unitL.Id;
            info.RoleInfoProto = unitL.roleInfo.ToMessage();
            return info;
        }
    }
}