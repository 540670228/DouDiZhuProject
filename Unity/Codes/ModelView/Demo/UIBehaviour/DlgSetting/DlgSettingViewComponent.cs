
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgSettingViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGToggle_VolumeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGToggle_VolumeRectTransform == null )
     			{
		    		this.m_EGToggle_VolumeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/SettingBK/BK/EGToggle_Volume");
     			}
     			return this.m_EGToggle_VolumeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGToggle_EffectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGToggle_EffectRectTransform == null )
     			{
		    		this.m_EGToggle_EffectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/SettingBK/BK/EGToggle_Effect");
     			}
     			return this.m_EGToggle_EffectRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGSlider_VolumeValueRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGSlider_VolumeValueRectTransform == null )
     			{
		    		this.m_EGSlider_VolumeValueRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround/SettingBK/BK/EGSlider_VolumeValue");
     			}
     			return this.m_EGSlider_VolumeValueRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_OKButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_OKButton == null )
     			{
		    		this.m_EButton_OKButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/SettingBK/EButton_OK");
     			}
     			return this.m_EButton_OKButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_OKImage == null )
     			{
		    		this.m_EButton_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/SettingBK/EButton_OK");
     			}
     			return this.m_EButton_OKImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_EGToggle_VolumeRectTransform = null;
			this.m_EGToggle_EffectRectTransform = null;
			this.m_EGSlider_VolumeValueRectTransform = null;
			this.m_EButton_OKButton = null;
			this.m_EButton_OKImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.RectTransform m_EGToggle_VolumeRectTransform = null;
		private UnityEngine.RectTransform m_EGToggle_EffectRectTransform = null;
		private UnityEngine.RectTransform m_EGSlider_VolumeValueRectTransform = null;
		private UnityEngine.UI.Button m_EButton_OKButton = null;
		private UnityEngine.UI.Image m_EButton_OKImage = null;
		public Transform uiTransform = null;
	}
}
