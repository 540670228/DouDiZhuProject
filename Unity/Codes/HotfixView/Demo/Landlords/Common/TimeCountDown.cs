using System;
using UnityEngine.UI;

namespace ET
{
    public static class TimeCountDown
    {
        /// <summary>
        /// 倒计时动画
        /// </summary>
        /// <param name="timeTxt">倒计时文本组件</param>
        /// <param name="totalTime">倒计时时长</param>
        /// <param name="callBack">结束回调函数</param>
        public async static ETTask startCountDown(Text timeTxt,int totalTime,ETCancellationToken token,Action callBack = null)
        {
            
            while (totalTime > 0 && !token.IsCancel())
            {
                if (timeTxt == null) return; //销毁场景时 计时器一并需要销毁
                timeTxt.text = totalTime.ToString();
                await TimerComponent.Instance.WaitAsync(1000,token);
                totalTime--;
            }
            //如果不是人为取消则进行CallBack
            if (!token.IsCancel())
            {
                callBack?.Invoke();
            }
        }
    }
}