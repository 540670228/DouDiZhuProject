namespace ET
{

    public static class RoleInfoSystem
    {
        //利用ProtoMessage信息初始化实体信息
        public static void FromMessage(this RoleInfo self, RoleInfoProto roleInfoProto)
        {
            self.Id = roleInfoProto.Id;
            self.Name = roleInfoProto.Name;
            self.HeadSpriteName = roleInfoProto.HeadSpriteName;
            self.PhotoSpriteName = roleInfoProto.PhotoSpriteName;
            self.goldCount = roleInfoProto.goldCount;
            self.diamond = roleInfoProto.diamond;
            self.AccountId = roleInfoProto.AccountId;
            self.LastLoginTime = roleInfoProto.LastLoginTime;
            self.CreateTime = roleInfoProto.CreateTime;

        }

        public static RoleInfoProto ToMessage(this RoleInfo self)
        {
            return new RoleInfoProto()
            {
                Id = self.Id,
                Name = self.Name,
                AccountId = self.AccountId,
                HeadSpriteName = self.HeadSpriteName,
                PhotoSpriteName = self.PhotoSpriteName,
                goldCount = self.goldCount,
                diamond = self.diamond,
                LastLoginTime = self.LastLoginTime,
                CreateTime = self.CreateTime,
            };
        }

        public static Sex getSex(this RoleInfo self)
        {
            if (self.PhotoSpriteName.EndsWith("0")) return Sex.girl;
            else return Sex.boy;
        }
    }
}
