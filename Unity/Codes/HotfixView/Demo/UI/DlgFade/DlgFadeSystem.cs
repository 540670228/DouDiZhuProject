using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgFadeSystem
	{

		public static void RegisterUIEvent(this DlgFade self)
		{
		 
		}

		public static void ShowWindow(this DlgFade self,Entity contextData = null)
		{
			

		}

		public async static void StartFade(this DlgFade self,WindowID lastWindow, WindowID nextWindow)
		{
			//开启一段异步逻辑淡出 淡入
			await self.FadeOut();
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(lastWindow);
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(nextWindow);
			await self.FadeIn();
		}
		
		private async static ETTask FadeOut(this DlgFade self)
		{
			CanvasGroup canvasGroup = self.View.EImage_FadeImage.GetComponent<CanvasGroup>();
			for (float i = 0; i <= 1; i+=0.01f)
			{
				await TimerComponent.Instance.WaitAsync(10);
				canvasGroup.alpha = i;
			}
		}
		
		private async static ETTask FadeIn(this DlgFade self)
		{
			CanvasGroup canvasGroup = self.View.EImage_FadeImage.GetComponent<CanvasGroup>();
			for (float i = 1; i >= 0; i-=0.01f)
			{
				await TimerComponent.Instance.WaitAsync(10);
				canvasGroup.alpha = i;
			}
		}

		 

	}
}
