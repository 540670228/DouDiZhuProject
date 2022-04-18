
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ESTipsUI : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EImage_TipsBKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_TipsBKImage == null )
     			{
		    		this.m_EImage_TipsBKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_TipsBK");
     			}
     			return this.m_EImage_TipsBKImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TipsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TipsText == null )
     			{
		    		this.m_ELabel_TipsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EImage_TipsBK/ELabel_Tips");
     			}
     			return this.m_ELabel_TipsText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_TipsBKImage = null;
			this.m_ELabel_TipsText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_TipsBKImage = null;
		private UnityEngine.UI.Text m_ELabel_TipsText = null;
		public Transform uiTransform = null;
	}
}
