
using System;

namespace ET
{
    /// <summary>
    /// 用来协助做服务器的验证
    /// </summary>
    public static class VerifyHelper
    {
        /// <summary>
        /// 服务器类型是否正确，需要手动释放Session
        /// </summary>
        public static bool VerifySceneType(Scene scene, SceneType type, IResponse response, Action reply)
        {
            //判断登录的是否为指定服务器
            if (scene.SceneType != type)
            {
                Log.Error($"请求的Scene错误，当前Scene为:{scene.SceneType}");
                response.Error = ErrorCode.ERR_SceneTypeError;
                reply();
                return false;
            }
            return true;
        }

        public static bool VerifyTheToken(Session session, long accountId, string clientToken, IResponse response, Action reply, Scene scene = null)
        {
            if (scene == null) scene = session.DomainScene();
            //Gate和普通服务器的令牌所在组件不同
            string serverToken = scene.GetComponent<TokenComponent>()?.Get(accountId);
            if (serverToken == null)
                serverToken = scene.GetComponent<GateSessionKeyComponent>()?.Get(accountId);

            if (serverToken == null || serverToken != clientToken)
            {
                ErrorHandler(session, response, ErrorCode.ERR_TokenError, reply);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证是否请求频繁，无需手动释放Session
        /// </summary>
        public static bool VerifyReaptedRequest(Session session, IResponse response, Action reply)
        {
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                ErrorHandler(session, response, ErrorCode.ERR_RequestReaptedError, reply);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 处理用户输入错误
        /// </summary>
        /// <param name="session">与客户端的连接</param>
        /// <param name="response">回复的消息</param>
        /// <param name="error">错误码</param>
        /// <param name="reply">回复消息委托</param>
        public static void ErrorHandler(Session session, IResponse response, int error, Action reply)
        {
            Log.Error(error.ToString());
            response.Error = error;
            reply();
            session?.DisConnect().Coroutine();
        }

        public static string GenerateRandomToken()
        {
            return TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
        }
    }
        
}
