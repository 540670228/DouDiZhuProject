
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 负责获取Errcode的描述信息
    /// </summary>
    public static class ErrorCodeHelper
    {
        private static Dictionary<int, string> ErrorCodeInfos = new Dictionary<int, string>();

        static ErrorCodeHelper()
        {
            //初始化错误信息字典
            var configs = ErrorInfoConfigCategory.Instance.GetAll();
            foreach (var config in configs)
            {
                ErrorCodeInfos.Add(config.Value.Errorcode,config.Value.ErrorInfo);
            }
        }
        
        public static string GetErrorInfo(int errorCode)
        {
            //大于300000的为调试信息 无需进行提示
            if (errorCode > 300000) return null;
            
            if (ErrorCodeInfos.ContainsKey(errorCode)) 
                return ErrorCodeInfos[errorCode];
            return null;
        }
        
        
    }
}