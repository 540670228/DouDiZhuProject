
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgFadeViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image EImage_FadeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_FadeImage == null )
     			{
		    		this.m_EImage_FadeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Fade");
     			}
     			return this.m_EImage_FadeImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_FadeImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_FadeImage = null;
		public Transform uiTransform = null;
	}
}
