using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 用于在服务器上保存每个账户Id对应的Token令牌
    /// </summary>
    public class TokenComponent : Entity, IAwake
    {
        public readonly Dictionary<long, string> TokenDictionary = new Dictionary<long, string>();
    }
}
