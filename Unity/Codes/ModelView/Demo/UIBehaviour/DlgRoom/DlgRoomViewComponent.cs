
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgRoomViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image EImage_Player1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Player1Image == null )
     			{
		    		this.m_EImage_Player1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player1");
     			}
     			return this.m_EImage_Player1Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_Logo1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Logo1Image == null )
     			{
		    		this.m_EImage_Logo1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player1/EImage_Logo1");
     			}
     			return this.m_EImage_Logo1Image;
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
		    		this.m_ELabel_Name1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player1/Image_InfoBK/ELabel_Name1");
     			}
     			return this.m_ELabel_Name1Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldCount1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldCount1Text == null )
     			{
		    		this.m_ELabel_GoldCount1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player1/Image_InfoBK/ELabel_GoldCount1");
     			}
     			return this.m_ELabel_GoldCount1Text;
     		}
     	}

		public UnityEngine.UI.Image EImage_Player2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Player2Image == null )
     			{
		    		this.m_EImage_Player2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player2");
     			}
     			return this.m_EImage_Player2Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_Logo2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Logo2Image == null )
     			{
		    		this.m_EImage_Logo2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player2/EImage_Logo2");
     			}
     			return this.m_EImage_Logo2Image;
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
		    		this.m_ELabel_Name2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player2/Image_InfoBK/ELabel_Name2");
     			}
     			return this.m_ELabel_Name2Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldCount2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldCount2Text == null )
     			{
		    		this.m_ELabel_GoldCount2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player2/Image_InfoBK/ELabel_GoldCount2");
     			}
     			return this.m_ELabel_GoldCount2Text;
     		}
     	}

		public UnityEngine.UI.Image EImage_Player0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Player0Image == null )
     			{
		    		this.m_EImage_Player0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player0");
     			}
     			return this.m_EImage_Player0Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_Logo0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Logo0Image == null )
     			{
		    		this.m_EImage_Logo0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player0/EImage_Logo0");
     			}
     			return this.m_EImage_Logo0Image;
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
		    		this.m_ELabel_Name0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player0/Image_InfoBK/ELabel_Name0");
     			}
     			return this.m_ELabel_Name0Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldCount0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldCount0Text == null )
     			{
		    		this.m_ELabel_GoldCount0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/EImage_Player0/Image_InfoBK/ELabel_GoldCount0");
     			}
     			return this.m_ELabel_GoldCount0Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_MultipleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_MultipleText == null )
     			{
		    		this.m_ELabel_MultipleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/Image_MultipleBK/ELabel_Multiple");
     			}
     			return this.m_ELabel_MultipleText;
     		}
     	}

		public UnityEngine.UI.Button EButton_AutoControlButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_AutoControlButton == null )
     			{
		    		this.m_EButton_AutoControlButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_RoomBK/EButton_AutoControl");
     			}
     			return this.m_EButton_AutoControlButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_AutoControlImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_AutoControlImage == null )
     			{
		    		this.m_EButton_AutoControlImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EButton_AutoControl");
     			}
     			return this.m_EButton_AutoControlImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_SetUpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SetUpButton == null )
     			{
		    		this.m_EButton_SetUpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_RoomBK/EButton_SetUp");
     			}
     			return this.m_EButton_SetUpButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_SetUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SetUpImage == null )
     			{
		    		this.m_EButton_SetUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EButton_SetUp");
     			}
     			return this.m_EButton_SetUpImage;
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
		    		this.m_EButton_ComeBackButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_RoomBK/EButton_ComeBack");
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
		    		this.m_EButton_ComeBackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RoomBK/EButton_ComeBack");
     			}
     			return this.m_EButton_ComeBackImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_BasicScoreText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_BasicScoreText == null )
     			{
		    		this.m_ELabel_BasicScoreText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/ELabel_BasicScore");
     			}
     			return this.m_ELabel_BasicScoreText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_MatchingNowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_MatchingNowText == null )
     			{
		    		this.m_ELabel_MatchingNowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_RoomBK/ELabel_MatchingNow");
     			}
     			return this.m_ELabel_MatchingNowText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_Player1Image = null;
			this.m_EImage_Logo1Image = null;
			this.m_ELabel_Name1Text = null;
			this.m_ELabel_GoldCount1Text = null;
			this.m_EImage_Player2Image = null;
			this.m_EImage_Logo2Image = null;
			this.m_ELabel_Name2Text = null;
			this.m_ELabel_GoldCount2Text = null;
			this.m_EImage_Player0Image = null;
			this.m_EImage_Logo0Image = null;
			this.m_ELabel_Name0Text = null;
			this.m_ELabel_GoldCount0Text = null;
			this.m_ELabel_MultipleText = null;
			this.m_EButton_AutoControlButton = null;
			this.m_EButton_AutoControlImage = null;
			this.m_EButton_SetUpButton = null;
			this.m_EButton_SetUpImage = null;
			this.m_EButton_ComeBackButton = null;
			this.m_EButton_ComeBackImage = null;
			this.m_ELabel_BasicScoreText = null;
			this.m_ELabel_MatchingNowText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_Player1Image = null;
		private UnityEngine.UI.Image m_EImage_Logo1Image = null;
		private UnityEngine.UI.Text m_ELabel_Name1Text = null;
		private UnityEngine.UI.Text m_ELabel_GoldCount1Text = null;
		private UnityEngine.UI.Image m_EImage_Player2Image = null;
		private UnityEngine.UI.Image m_EImage_Logo2Image = null;
		private UnityEngine.UI.Text m_ELabel_Name2Text = null;
		private UnityEngine.UI.Text m_ELabel_GoldCount2Text = null;
		private UnityEngine.UI.Image m_EImage_Player0Image = null;
		private UnityEngine.UI.Image m_EImage_Logo0Image = null;
		private UnityEngine.UI.Text m_ELabel_Name0Text = null;
		private UnityEngine.UI.Text m_ELabel_GoldCount0Text = null;
		private UnityEngine.UI.Text m_ELabel_MultipleText = null;
		private UnityEngine.UI.Button m_EButton_AutoControlButton = null;
		private UnityEngine.UI.Image m_EButton_AutoControlImage = null;
		private UnityEngine.UI.Button m_EButton_SetUpButton = null;
		private UnityEngine.UI.Image m_EButton_SetUpImage = null;
		private UnityEngine.UI.Button m_EButton_ComeBackButton = null;
		private UnityEngine.UI.Image m_EButton_ComeBackImage = null;
		private UnityEngine.UI.Text m_ELabel_BasicScoreText = null;
		private UnityEngine.UI.Text m_ELabel_MatchingNowText = null;
		public Transform uiTransform = null;
	}
}
