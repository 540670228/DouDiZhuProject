using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

namespace ET
{
    public static class TokenComponentSystem
    {
        /// <summary>
        /// 添加令牌的方法
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="token"></param>
        public static void Add(this TokenComponent self, long key, string token)
        {
            self.TokenDictionary.Add(key, token);
            //10分钟后自动删除令牌
            self.TimeOutRemoveKey(key, token).Coroutine();
        }

        /// <summary>
        /// 获取令牌的方法
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(this TokenComponent self, long key)
        {
            string value = null;
            self.TokenDictionary.TryGetValue(key, out value);
            return value;
        }

        /// <summary>
        /// 移除令牌的方法
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        public static void Remove(this TokenComponent self, long key)
        {
            if (self.TokenDictionary.ContainsKey(key))
                self.TokenDictionary.Remove(key);
        }

        private static async ETTask TimeOutRemoveKey(this TokenComponent self, long key, string token)
        {
            //等待10分钟
            await TimerComponent.Instance.WaitAsync(6000 * 10);

            string onLineToken = self.Get(key);

            //令牌不为空且一致 到时删除
            if (!string.IsNullOrEmpty(onLineToken) && onLineToken == token)
            {
                self.Remove(key);
            }
        }

        public static bool isExist(this TokenComponent self, long accountId)
        {
            return self.TokenDictionary.ContainsKey(accountId);
        }

    }
}
