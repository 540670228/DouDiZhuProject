using System;


namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            //接收账号服务器返回消息：AccountId和Token
            A2C_LoginAccount a2C_LoginAccount = null;
            //创建请求登录账号消息
            C2A_LoginAccount c2ALoginAccount = new C2A_LoginAccount()
            {
                AccountName = account,
                //密码用md5码加密传输，不能明文传输
                Password = MD5Helper.StringMD5(password),
            };
            //与账号服务器连接的Session会话
            Session accountSession = null;
            
            try
            {
                //获取与账号服务器的连接
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                
                //向账号服务器发送消息
                a2C_LoginAccount = await accountSession.Call(c2ALoginAccount) as A2C_LoginAccount;
                
            }
            catch (Exception e)
            {
                accountSession?.Dispose();
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            
            //判断错误码
            if (a2C_LoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                Log.Error(a2C_LoginAccount.Error.ToString());
                //返回错误码
                return a2C_LoginAccount.Error;
            }
            
            //若成功返回 则记录保存账户信息AccountId Token
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2C_LoginAccount.AccountId;
            zoneScene.GetComponent<AccountInfoComponent>().Token = a2C_LoginAccount.Token;

            Log.Debug("登录成功");
            return ErrorCode.ERR_Success;
        }
    }
}