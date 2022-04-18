using System;
using System.Collections;
using UnityEngine;

namespace ET
{
    public static class UITween
    {
        public async static ETTask MoveToLocalPos(this RectTransform rect,Vector3 offset,float speed, Action callBack = null)
        {
            Vector3 endPos = rect.anchoredPosition3D + offset;
            int safe = 100;
            while (Vector3.Distance(rect.anchoredPosition3D,endPos) > 2f)
            {
                rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition3D, endPos, speed*Time.deltaTime);
                await TimerComponent.Instance.WaitAsync((long)(1000*Time.deltaTime));
                if (safe-- < 0) break;
                if (rect == null) return;
            }
            //保证位置精准 直接等于
            rect.anchoredPosition3D = endPos;
            callBack?.Invoke();
        }

        //组件的缩放
        public async static ETTask StartScaleTween(this Transform tf, float mul, float speed, Action callBack = null)
        {
            Vector3 targetScale = Vector3.one * mul;
            while (true)
            {
                if (tf.localScale.x - targetScale.x > 0) break;
                tf.localScale = tf.localScale + Vector3.one * Time.deltaTime * speed;
                await TimerComponent.Instance.WaitAsync((int) (Time.deltaTime * 1000));
            }

            while (true)
            {
                if (tf.localScale.x - 1 < 0) break;
                tf.localScale = tf.localScale - Vector3.one * Time.deltaTime * speed;
                await TimerComponent.Instance.WaitAsync((int) (Time.deltaTime * 1000));
            }
            
            tf.localScale = Vector3.one;
            callBack?.Invoke();
            
            await ETTask.CompletedTask;
        }


        public async static ETTask MoveFromLocalPos(this RectTransform rect, Vector2 startPos, float speed, Action callBack = null)
        {
            Vector2 targetPos = rect.anchoredPosition;
            rect.anchoredPosition = startPos;
            while (Vector2.Distance(rect.anchoredPosition, targetPos) > 1)
            {
                rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, targetPos, speed * Time.deltaTime);
                await TimerComponent.Instance.WaitAsync((int) (Time.deltaTime * 1000));
            }

            rect.anchoredPosition = targetPos;
            
            callBack?.Invoke();
        }

        public async static ETTask MoveToTargetPos(this RectTransform rect, Vector2 targetPos, float speed, Action callBack=null)
        {
            while (Vector2.Distance(rect.anchoredPosition, targetPos) > 1)
            {
                rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, targetPos, speed * Time.deltaTime);
                await TimerComponent.Instance.WaitAsync((int) (Time.deltaTime * 1000));
            }
            
            rect.anchoredPosition = targetPos;
            
            callBack?.Invoke();

            await ETTask.CompletedTask;
        }
        
    }
}