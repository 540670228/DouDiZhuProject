using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class C2A_LoginAccountHandler : AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
            //对账号服务器进行验证
            if(!VerifyHelper.VerifySceneType(session.DomainScene(),SceneType.Account,response,reply))
            {
                session?.DisConnect().Coroutine();
                return;
            }

            //验证是否请求频繁
            if(!VerifyHelper.VerifyReaptedRequest(session,response,reply))
            {
                return;
            }
            
            //移除验证组件
            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            

            //避免请求频繁
            using(session.AddComponent<SessionLockingComponent>())
            {
                //涉及到异步操作写入数据库等操作，将登录账号相同的进行上锁
                using(await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount,request.AccountName.GetHashCode()))
                {
                    //从数据库获取Account
                    Account account = await GetAccountFromDB(session, request.AccountName);

                    //账号存在验证合法性，不存在则进行注册
                    if (account != null)
                    {
                        //将账号实体加到session的Scene下
                        session.AddChild(account);

                        //合法性检测---是否在黑名单中
                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            VerifyHelper.ErrorHandler(session, response, ErrorCode.ERR_AccountInBlackListError, reply);
                            account?.Dispose();
                            return;
                        }

                        //判断登录密码是否一致
                        if (!account.PassWord.Equals(request.Password))
                        {
                            VerifyHelper.ErrorHandler(session, response, ErrorCode.ERR_LoginPasswordError, reply);
                            account?.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        //对账号进行注册
                        account = await RegisterAccount(session,request);
                    }

                    //进行顶号处理  登陆中心服务器记录着当前角色所在网关服务器
                    int errorCode = await NoticeLoginCenter(session, account.Id);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        VerifyHelper.ErrorHandler(session,response,errorCode,reply);
                        return;
                    }

                    //随机生成令牌 和 账户Id一齐发送回客户端
                    string token = VerifyHelper.GenerateRandomToken();
                    //加入前先移除 顶号操作
                    session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                    //将令牌缓存到组件中，用于后续交互的验证
                    session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, token);
                    
                    response.Token = token;
                    response.AccountId = account.Id;
                    response.Error = ErrorCode.ERR_Success;
                    reply();
                    Log.Debug("账号登录成功");

                }
                    
            }
            
        }

        //从DB中获取账户信息
        private async ETTask<Account> GetAccountFromDB(Session session,String accountName)
        {
            //根据账号名称，获取数据库中的账号列表
            var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<Account>(
                acount => acount.AccountName.Equals(accountName.Trim())
            );
            //判断是否获取到账号
            if (accountInfoList != null && accountInfoList.Count > 0)
            {
                return accountInfoList[0];
            }
            else return null;

        }
        //注册账号信息写入数据库
        private async ETTask<Account> RegisterAccount(Session session,C2A_LoginAccount request)
        {
            Account account = null;
            //在session实体下创建一个Account实体
            account = session.AddChild<Account>();
            account.AccountName = request.AccountName;
            account.PassWord = request.Password;
            account.CreateTime = TimeHelper.ServerNow();
            account.AccountType = (int)AccountType.Normal;

            //保存至数据库中
            await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);

            return account;
        }

        //通知LoginCenter完成顶号操作
        private async ETTask<int> NoticeLoginCenter(Session session,long AccounId)
        {
            
            A2L_RobGateSession a2L_RobGateSession = new A2L_RobGateSession() { AccountId = AccounId, };
            L2A_RobGateSession l2A_RobGateSession = null;
            
            //获取LoginCenter的InstanceId
            long LoginCenterInstanceId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;

            try
            {
                //向LoginCenter发送顶号消息
                l2A_RobGateSession = await MessageHelper.
                        CallActor(LoginCenterInstanceId, a2L_RobGateSession) as L2A_RobGateSession;

                //如果出错 返回错误码
                if (l2A_RobGateSession.Error != ErrorCode.ERR_Success)
                {
                    return l2A_RobGateSession.Error;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return ErrorCode.ERR_Success;
        }
    }
}
