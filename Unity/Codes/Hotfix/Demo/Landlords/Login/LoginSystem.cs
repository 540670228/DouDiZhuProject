using System;

namespace ET
{
    public static class LoginSystem
    {
        /// <summary>
        /// 登录进账号服务器
        /// </summary>
        /// <param name="zoneScene"></param>
        /// <param name="address">账号服务器外网Address</param>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
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
            //保存与账号服务器的连接
            zoneScene.GetComponent<SessionComponent>().Session = accountSession;
            accountSession.AddComponent<PingComponent>(); //添加心跳组件防止掉线

            Log.Debug("登录成功");
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2C_GetRealmKey = null;

            try
            {
                a2C_GetRealmKey = await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = ConstValue.ServerId,
                }) as A2C_GetRealmKey;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2C_GetRealmKey.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRealmKey.Error.ToString());
                return a2C_GetRealmKey.Error;
            }

            //将均衡服务器下发的网关服务器地址和验证令牌保存起来
            zoneScene.GetComponent<AccountInfoComponent>().RealmKey = a2C_GetRealmKey.RealmKey;
            zoneScene.GetComponent<AccountInfoComponent>().RealmAddress = a2C_GetRealmKey.RealmAddress;

            //然后与账号服务器断开 断开前移除令牌
            zoneScene.GetComponent<SessionComponent>().Session?.Dispose();

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRoleInfo(Scene zoneScene)
        {
            //向服务器发送消息获取指定 账户 指定区服的角色
            A2C_GetRole a2C_GetRole = null;
            try
            {
                //发送消息
                a2C_GetRole = await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRole() { 
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    ServerId = ConstValue.ServerId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                }) as A2C_GetRole;
                Log.Debug("GetRole消息回复成功");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2C_GetRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRole.Error.ToString());

                return a2C_GetRole.Error;
            }

            if (a2C_GetRole.RoleInfo != null)
            {
                RoleInfo roleInfo = zoneScene.GetComponent<RoleInfoComponent>().AddChild<RoleInfo>();
                Log.Warning("回复的RoleInfo为空吗"+(a2C_GetRole.RoleInfo == null));
                roleInfo.FromMessage(a2C_GetRole.RoleInfo);
                zoneScene.GetComponent<RoleInfoComponent>().roleInfo = roleInfo;
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRoleInfo(Scene zoneScene,string roleName,string headName,string charName)
        {
            A2C_CreateRole a2C_CreateRole = null;
            try
            {
                //向账号服务器发送请求创建角色的信息
                a2C_CreateRole = await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreateRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Name = roleName,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = ConstValue.ServerId,
                    headName = headName,
                    charName = charName,
                }) as A2C_CreateRole;

                if(a2C_CreateRole.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(a2C_CreateRole.Error.ToString());
                    return a2C_CreateRole.Error;
                }


                RoleInfo roleInfo = zoneScene.GetComponent<RoleInfoComponent>().AddChild<RoleInfo>();
                roleInfo.FromMessage(a2C_CreateRole.RoleInfo);
                //接收到服务端创建的角色信息缓存起来
                zoneScene.GetComponent<RoleInfoComponent>().roleInfo = roleInfo;

            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> EnterGame(Scene zoneScene)
        {
            //总体逻辑
            //1.连接Realm发送消息请求获取分配一个Gate网关
            //2.Realm返回一个网关地址和验证令牌
            //3.连接Gate网关，创建Player映射对象
            //4.在游戏服务器上创建Unit映射对象


            //======================与Realm网关的交互===================================
            //获取Realm网关地址
            string realmAddress = zoneScene.GetComponent<AccountInfoComponent>().RealmAddress;
            Log.Debug("Realm网关的内网地址为 ： "+realmAddress);
            //与Realm网关建立连接
            Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));
            Log.Debug("Realm网关Session是否已经释放" + (session == null || session.IsDisposed).ToString());
            R2C_LoginRealm r2C_LoginRealm = null;
            try
            {
                r2C_LoginRealm = await session.Call(new C2R_LoginRealm()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RealmKey = zoneScene.GetComponent<AccountInfoComponent>().RealmKey,
                }) as R2C_LoginRealm;


            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            //断开和Realm服务器的连接
            session?.Dispose();
            if (r2C_LoginRealm == null || r2C_LoginRealm.Error != ErrorCode.ERR_Success)
            {
                Log.Error(r2C_LoginRealm.Error.ToString());
                return r2C_LoginRealm.Error;
            }


            //====================与Gate网关进行交互================================
            Log.Warning($"GateAddress : {r2C_LoginRealm.GateAddress}");

            //建立与gate网关的连接
            Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2C_LoginRealm.GateAddress));
            //添加心跳组件并保存连接
            gateSession.AddComponent<PingComponent>();
            zoneScene.GetComponent<SessionComponent>().Session = gateSession;

            //向Gate发送消息建立连接

            G2C_LoginGameGate g2C_LoginGameGate = null;

            try
            {
                g2C_LoginGameGate = await gateSession.Call(new C2G_LoginGameGate()
                {
                    RoleId = zoneScene.GetComponent<RoleInfoComponent>().roleInfo.Id,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId, GateKey = r2C_LoginRealm.GateSessionKey,
                }) as G2C_LoginGameGate;


            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_LoginGameGate.Error != ErrorCode.ERR_Success)
            {
                zoneScene.GetComponent<SessionComponent>().Session?.Dispose();
                Log.Error(g2C_LoginGameGate.Error.ToString());
                return g2C_LoginGameGate.Error;
            }

            Log.Debug("登录gate成功！！");


            //==================角色请求进入游戏逻辑服务器====================
            G2C_EnterGame g2C_EnterGAME = null;
            try
            {
                g2C_EnterGAME = await gateSession.Call(new C2G_EnterGame()
                {
                    roleInfoProto = zoneScene.GetComponent<RoleInfoComponent>().roleInfo.ToMessage(),
                }) as G2C_EnterGame;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_EnterGAME.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_EnterGAME.Error.ToString());
                return g2C_EnterGAME.Error;
            }

            //将UnitId缓存到CurrentScene下的MyUnitComponent
            zoneScene.GetComponent<MyUnitLComponent>().unitL =
                    zoneScene.GetComponent<CurrentScenesComponent>().Scene.GetComponent<UnitLComponent>().Get(g2C_EnterGAME.MyId);
            
            Log.Debug("角色进入游戏成功！");

            return ErrorCode.ERR_Success;

        }

        public static async ETTask<int> ExitGame(Scene zoneScene)
        {
            Log.Debug("开始下线逻辑");
            //通过向网关服务器发送下线消息，网关服务器再向LoginCenter发送下线消息
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            if (gateSession == null || gateSession.IsDisposed)
            {
                return ErrorCode.ERR_GateSessionIsNull;
            }

            try
            {
                G2C_ExitGame g2C_ExitGame = await gateSession.Call(new C2G_ExitGame()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                }) as G2C_ExitGame;

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }


            Log.Debug("游戏下线成功");
            return ErrorCode.ERR_Success;
        }
    }
}
