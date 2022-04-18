
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgLandlordsLobbyViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image EImage_RoleHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_RoleHeadImage == null )
     			{
		    		this.m_EImage_RoleHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/EImage_RoleHead");
     			}
     			return this.m_EImage_RoleHeadImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_RoleNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_RoleNameText == null )
     			{
		    		this.m_ELabel_RoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/ELabel_RoleName");
     			}
     			return this.m_ELabel_RoleNameText;
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
		    		this.m_E_LevelSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/E_Level");
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
		    		this.m_E_LevelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/E_Level");
     			}
     			return this.m_E_LevelImage;
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
		    		this.m_ELabel_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/E_Level/ELabel_Level");
     			}
     			return this.m_ELabel_LevelText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_GoldCountText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_GoldCountText == null )
     			{
		    		this.m_ELabel_GoldCountText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/Image_GoldBackGround/ELabel_GoldCount");
     			}
     			return this.m_ELabel_GoldCountText;
     		}
     	}

		public UnityEngine.UI.Button EButton_AddGoldButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_AddGoldButton == null )
     			{
		    		this.m_EButton_AddGoldButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/Image_GoldBackGround/EButton_AddGold");
     			}
     			return this.m_EButton_AddGoldButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_AddGoldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_AddGoldImage == null )
     			{
		    		this.m_EButton_AddGoldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/Image_GoldBackGround/EButton_AddGold");
     			}
     			return this.m_EButton_AddGoldImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_DiamondCountText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_DiamondCountText == null )
     			{
		    		this.m_ELabel_DiamondCountText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/Image_DiamondBackGround/ELabel_DiamondCount");
     			}
     			return this.m_ELabel_DiamondCountText;
     		}
     	}

		public UnityEngine.UI.Button EButton_AddDiamondButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_AddDiamondButton == null )
     			{
		    		this.m_EButton_AddDiamondButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/Image_DiamondBackGround/EButton_AddDiamond");
     			}
     			return this.m_EButton_AddDiamondButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_AddDiamondImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_AddDiamondImage == null )
     			{
		    		this.m_EButton_AddDiamondImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/Image_DiamondBackGround/EButton_AddDiamond");
     			}
     			return this.m_EButton_AddDiamondImage;
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
		    		this.m_EButton_SetUpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/EButton_SetUp");
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
		    		this.m_EButton_SetUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_LobbyBK/Image_InfoBK/EButton_SetUp");
     			}
     			return this.m_EButton_SetUpImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_MatchingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_MatchingButton == null )
     			{
		    		this.m_EButton_MatchingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_LobbyBK/EButton_Matching");
     			}
     			return this.m_EButton_MatchingButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_MatchingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_MatchingImage == null )
     			{
		    		this.m_EButton_MatchingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_LobbyBK/EButton_Matching");
     			}
     			return this.m_EButton_MatchingImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_ScoreTitleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ScoreTitleButton == null )
     			{
		    		this.m_EButton_ScoreTitleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_RankBK/Image_RankTitleBK/EButton_ScoreTitle");
     			}
     			return this.m_EButton_ScoreTitleButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ScoreTitleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ScoreTitleImage == null )
     			{
		    		this.m_EButton_ScoreTitleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RankBK/Image_RankTitleBK/EButton_ScoreTitle");
     			}
     			return this.m_EButton_ScoreTitleImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_GoldTitleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_GoldTitleButton == null )
     			{
		    		this.m_EButton_GoldTitleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image_RankBK/Image_RankTitleBK/EButton_GoldTitle");
     			}
     			return this.m_EButton_GoldTitleButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_GoldTitleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_GoldTitleImage == null )
     			{
		    		this.m_EButton_GoldTitleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image_RankBK/Image_RankTitleBK/EButton_GoldTitle");
     			}
     			return this.m_EButton_GoldTitleImage;
     		}
     	}

		public ESTipsUI ESTipsUI
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_estipsui == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ESTipsUI");
		    	   this.m_estipsui = this.AddChild<ESTipsUI,Transform>(subTrans);
     			}
     			return this.m_estipsui;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_RoleHeadImage = null;
			this.m_ELabel_RoleNameText = null;
			this.m_E_LevelSlider = null;
			this.m_E_LevelImage = null;
			this.m_ELabel_LevelText = null;
			this.m_ELabel_GoldCountText = null;
			this.m_EButton_AddGoldButton = null;
			this.m_EButton_AddGoldImage = null;
			this.m_ELabel_DiamondCountText = null;
			this.m_EButton_AddDiamondButton = null;
			this.m_EButton_AddDiamondImage = null;
			this.m_EButton_SetUpButton = null;
			this.m_EButton_SetUpImage = null;
			this.m_EButton_MatchingButton = null;
			this.m_EButton_MatchingImage = null;
			this.m_EButton_ScoreTitleButton = null;
			this.m_EButton_ScoreTitleImage = null;
			this.m_EButton_GoldTitleButton = null;
			this.m_EButton_GoldTitleImage = null;
			this.m_estipsui?.Dispose();
			this.m_estipsui = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_RoleHeadImage = null;
		private UnityEngine.UI.Text m_ELabel_RoleNameText = null;
		private UnityEngine.UI.Slider m_E_LevelSlider = null;
		private UnityEngine.UI.Image m_E_LevelImage = null;
		private UnityEngine.UI.Text m_ELabel_LevelText = null;
		private UnityEngine.UI.Text m_ELabel_GoldCountText = null;
		private UnityEngine.UI.Button m_EButton_AddGoldButton = null;
		private UnityEngine.UI.Image m_EButton_AddGoldImage = null;
		private UnityEngine.UI.Text m_ELabel_DiamondCountText = null;
		private UnityEngine.UI.Button m_EButton_AddDiamondButton = null;
		private UnityEngine.UI.Image m_EButton_AddDiamondImage = null;
		private UnityEngine.UI.Button m_EButton_SetUpButton = null;
		private UnityEngine.UI.Image m_EButton_SetUpImage = null;
		private UnityEngine.UI.Button m_EButton_MatchingButton = null;
		private UnityEngine.UI.Image m_EButton_MatchingImage = null;
		private UnityEngine.UI.Button m_EButton_ScoreTitleButton = null;
		private UnityEngine.UI.Image m_EButton_ScoreTitleImage = null;
		private UnityEngine.UI.Button m_EButton_GoldTitleButton = null;
		private UnityEngine.UI.Image m_EButton_GoldTitleImage = null;
		private ESTipsUI m_estipsui = null;
		public Transform uiTransform = null;
	}
}
