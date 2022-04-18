namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        
        //需要进行提示的错误码 200001以上 需在Excel中配置用户提示信息
        public const int ERR_AccountFormatError = 200001; //账号密码格式错误
        public const int ERR_NetWorkError = 200002;    //网络连接错误
        public const int ERR_RequestReaptedError = 200003; //请求过于频繁
        public const int ERR_LoginPasswordError = 200004;  //账号的密码错误
        public const int ERR_AccountInBlackListError = 200005; //账号被封禁
        public const int ERR_OtherAccountLogin = 200006;  //被其它账户顶号
        public const int ERR_RoleNameSame = 200007;  //用户名重复
        public const int ERR_RoleNameIsNull = 200008; //用户名为空
        public const int ERR_PokerListTypeError = 200009; //牌型不符合规范


        //调试用错误码  300001以上
        public const int ERR_SceneTypeError = 300001;  //选择服务器错误
        public const int ERR_TokenError = 300002;      //令牌验证错误
        public const int ERR_GateSessionIsNull = 300003; //网关连接已断开仍尝试断开
        public const int ERR_SessionPlayerIsNull = 300004; //创建Unit时SessionPlayer组件为Null
        public const int ERR_NonePlayerError = 300005; //创建Unit时 Player为空
        public const int ERR_ReEnterGameError = 300006; //二次顶号登录失败
        public const int ERR_EnterGameError = 300007;  //角色进入大厅失败
    }
}