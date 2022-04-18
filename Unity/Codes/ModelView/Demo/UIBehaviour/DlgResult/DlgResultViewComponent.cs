
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgResultViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image EImage_PlayerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_PlayerImage == null )
     			{
		    		this.m_EImage_PlayerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/EImage_Player");
     			}
     			return this.m_EImage_PlayerImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_ResultImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_ResultImage == null )
     			{
		    		this.m_EImage_ResultImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/EImage_Result");
     			}
     			return this.m_EImage_ResultImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_HeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_HeadImage == null )
     			{
		    		this.m_EImage_HeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/EImage_Head");
     			}
     			return this.m_EImage_HeadImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_LevelText == null )
     			{
		    		this.m_ELabel_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/EImage_Head/ELabel_Level");
     			}
     			return this.m_ELabel_LevelText;
     		}
     	}

		public UnityEngine.UI.Slider E_LevelSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelSlider == null )
     			{
		    		this.m_E_LevelSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"BK/Image_ResultBK/EImage_Head/E_Level");
     			}
     			return this.m_E_LevelSlider;
     		}
     	}

		public UnityEngine.UI.Image E_LevelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LevelImage == null )
     			{
		    		this.m_E_LevelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/EImage_Head/E_Level");
     			}
     			return this.m_E_LevelImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_Lord0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Lord0Image == null )
     			{
		    		this.m_EImage_Lord0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK0/EImage_Lord0");
     			}
     			return this.m_EImage_Lord0Image;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Name0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Name0Text == null )
     			{
		    		this.m_ELabel_Name0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK0/ELabel_Name0");
     			}
     			return this.m_ELabel_Name0Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_BasicCore0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_BasicCore0Text == null )
     			{
		    		this.m_ELabel_BasicCore0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK0/ELabel_BasicCore0");
     			}
     			return this.m_ELabel_BasicCore0Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Mutiple0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Mutiple0Text == null )
     			{
		    		this.m_ELabel_Mutiple0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK0/ELabel_Mutiple0");
     			}
     			return this.m_ELabel_Mutiple0Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldDelta0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldDelta0Text == null )
     			{
		    		this.m_ELabel_GoldDelta0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK0/ELabel_GoldDelta0");
     			}
     			return this.m_ELabel_GoldDelta0Text;
     		}
     	}

		public UnityEngine.UI.Image EImage_Lord1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Lord1Image == null )
     			{
		    		this.m_EImage_Lord1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK1/EImage_Lord1");
     			}
     			return this.m_EImage_Lord1Image;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Name1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Name1Text == null )
     			{
		    		this.m_ELabel_Name1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK1/ELabel_Name1");
     			}
     			return this.m_ELabel_Name1Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_BasicCore1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_BasicCore1Text == null )
     			{
		    		this.m_ELabel_BasicCore1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK1/ELabel_BasicCore1");
     			}
     			return this.m_ELabel_BasicCore1Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Mutiple1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Mutiple1Text == null )
     			{
		    		this.m_ELabel_Mutiple1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK1/ELabel_Mutiple1");
     			}
     			return this.m_ELabel_Mutiple1Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldDelta1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldDelta1Text == null )
     			{
		    		this.m_ELabel_GoldDelta1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK1/ELabel_GoldDelta1");
     			}
     			return this.m_ELabel_GoldDelta1Text;
     		}
     	}

		public UnityEngine.UI.Image EImage_Lord2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Lord2Image == null )
     			{
		    		this.m_EImage_Lord2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK2/EImage_Lord2");
     			}
     			return this.m_EImage_Lord2Image;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Name2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Name2Text == null )
     			{
		    		this.m_ELabel_Name2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK2/ELabel_Name2");
     			}
     			return this.m_ELabel_Name2Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_BasicCore2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_BasicCore2Text == null )
     			{
		    		this.m_ELabel_BasicCore2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK2/ELabel_BasicCore2");
     			}
     			return this.m_ELabel_BasicCore2Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Mutiple2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Mutiple2Text == null )
     			{
		    		this.m_ELabel_Mutiple2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK2/ELabel_Mutiple2");
     			}
     			return this.m_ELabel_Mutiple2Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldDelta2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldDelta2Text == null )
     			{
		    		this.m_ELabel_GoldDelta2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_ResultBK/Image_InfoBK2/ELabel_GoldDelta2");
     			}
     			return this.m_ELabel_GoldDelta2Text;
     		}
     	}

		public UnityEngine.UI.Button EButton_ContinueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ContinueButton == null )
     			{
		    		this.m_EButton_ContinueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BK/Image_ResultBK/EButton_Continue");
     			}
     			return this.m_EButton_ContinueButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ContinueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ContinueImage == null )
     			{
		    		this.m_EButton_ContinueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/Image_ResultBK/EButton_Continue");
     			}
     			return this.m_EButton_ContinueImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_ComeBackButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ComeBackButton == null )
     			{
		    		this.m_EButton_ComeBackButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BK/EButton_ComeBack");
     			}
     			return this.m_EButton_ComeBackButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ComeBackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ComeBackImage == null )
     			{
		    		this.m_EButton_ComeBackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/EButton_ComeBack");
     			}
     			return this.m_EButton_ComeBackImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_PlayerImage = null;
			this.m_EImage_ResultImage = null;
			this.m_EImage_HeadImage = null;
			this.m_ELabel_LevelText = null;
			this.m_E_LevelSlider = null;
			this.m_E_LevelImage = null;
			this.m_EImage_Lord0Image = null;
			this.m_ELabel_Name0Text = null;
			this.m_ELabel_BasicCore0Text = null;
			this.m_ELabel_Mutiple0Text = null;
			this.m_ELabel_GoldDelta0Text = null;
			this.m_EImage_Lord1Image = null;
			this.m_ELabel_Name1Text = null;
			this.m_ELabel_BasicCore1Text = null;
			this.m_ELabel_Mutiple1Text = null;
			this.m_ELabel_GoldDelta1Text = null;
			this.m_EImage_Lord2Image = null;
			this.m_ELabel_Name2Text = null;
			this.m_ELabel_BasicCore2Text = null;
			this.m_ELabel_Mutiple2Text = null;
			this.m_ELabel_GoldDelta2Text = null;
			this.m_EButton_ContinueButton = null;
			this.m_EButton_ContinueImage = null;
			this.m_EButton_ComeBackButton = null;
			this.m_EButton_ComeBackImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_PlayerImage = null;
		private UnityEngine.UI.Image m_EImage_ResultImage = null;
		private UnityEngine.UI.Image m_EImage_HeadImage = null;
		private UnityEngine.UI.Text m_ELabel_LevelText = null;
		private UnityEngine.UI.Slider m_E_LevelSlider = null;
		private UnityEngine.UI.Image m_E_LevelImage = null;
		private UnityEngine.UI.Image m_EImage_Lord0Image = null;
		private UnityEngine.UI.Text m_ELabel_Name0Text = null;
		private UnityEngine.UI.Text m_ELabel_BasicCore0Text = null;
		private UnityEngine.UI.Text m_ELabel_Mutiple0Text = null;
		private UnityEngine.UI.Text m_ELabel_GoldDelta0Text = null;
		private UnityEngine.UI.Image m_EImage_Lord1Image = null;
		private UnityEngine.UI.Text m_ELabel_Name1Text = null;
		private UnityEngine.UI.Text m_ELabel_BasicCore1Text = null;
		private UnityEngine.UI.Text m_ELabel_Mutiple1Text = null;
		private UnityEngine.UI.Text m_ELabel_GoldDelta1Text = null;
		private UnityEngine.UI.Image m_EImage_Lord2Image = null;
		private UnityEngine.UI.Text m_ELabel_Name2Text = null;
		private UnityEngine.UI.Text m_ELabel_BasicCore2Text = null;
		private UnityEngine.UI.Text m_ELabel_Mutiple2Text = null;
		private UnityEngine.UI.Text m_ELabel_GoldDelta2Text = null;
		private UnityEngine.UI.Button m_EButton_ContinueButton = null;
		private UnityEngine.UI.Image m_EButton_ContinueImage = null;
		private UnityEngine.UI.Button m_EButton_ComeBackButton = null;
		private UnityEngine.UI.Image m_EButton_ComeBackImage = null;
		public Transform uiTransform = null;
	}
}
