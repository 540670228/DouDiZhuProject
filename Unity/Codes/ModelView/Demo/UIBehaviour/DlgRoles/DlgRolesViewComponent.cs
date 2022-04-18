
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Image EImage_CreateRootImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_CreateRootImage == null )
     			{
		    		this.m_EImage_CreateRootImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot");
     			}
     			return this.m_EImage_CreateRootImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateRoleButton == null )
     			{
		    		this.m_EButton_CreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EButton_CreateRole");
     			}
     			return this.m_EButton_CreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateRoleImage == null )
     			{
		    		this.m_EButton_CreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EButton_CreateRole");
     			}
     			return this.m_EButton_CreateRoleImage;
     		}
     	}

		public UnityEngine.UI.InputField EInput_RoleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RoleNameInputField == null )
     			{
		    		this.m_EInput_RoleNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EButton_CreateRole/EInput_RoleName");
     			}
     			return this.m_EInput_RoleNameInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_RoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_RoleNameImage == null )
     			{
		    		this.m_EInput_RoleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EButton_CreateRole/EInput_RoleName");
     			}
     			return this.m_EInput_RoleNameImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_RolePhotoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_RolePhotoImage == null )
     			{
		    		this.m_EImage_RolePhotoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EImage_RolePhoto");
     			}
     			return this.m_EImage_RolePhotoImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_ChangePhotoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChangePhotoButton == null )
     			{
		    		this.m_EButton_ChangePhotoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EImage_RolePhoto/EButton_ChangePhoto");
     			}
     			return this.m_EButton_ChangePhotoButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ChangePhotoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChangePhotoImage == null )
     			{
		    		this.m_EButton_ChangePhotoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EImage_RolePhoto/EButton_ChangePhoto");
     			}
     			return this.m_EButton_ChangePhotoImage;
     		}
     	}

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
		    		this.m_EImage_RoleHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EImage_RoleHead");
     			}
     			return this.m_EImage_RoleHeadImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_ChangeHeadButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChangeHeadButton == null )
     			{
		    		this.m_EButton_ChangeHeadButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EImage_RoleHead/EButton_ChangeHead");
     			}
     			return this.m_EButton_ChangeHeadButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ChangeHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChangeHeadImage == null )
     			{
		    		this.m_EButton_ChangeHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_CreateRoot/EImage_RoleHead/EButton_ChangeHead");
     			}
     			return this.m_EButton_ChangeHeadImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_RoleInfoRootImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_RoleInfoRootImage == null )
     			{
		    		this.m_EImage_RoleInfoRootImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot");
     			}
     			return this.m_EImage_RoleInfoRootImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_StartGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_StartGameButton == null )
     			{
		    		this.m_EButton_StartGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/EButton_StartGame");
     			}
     			return this.m_EButton_StartGameButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_StartGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_StartGameImage == null )
     			{
		    		this.m_EButton_StartGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/EButton_StartGame");
     			}
     			return this.m_EButton_StartGameImage;
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
		    		this.m_ELabel_RoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/RoleNameRoot/ELabel_RoleName");
     			}
     			return this.m_ELabel_RoleNameText;
     		}
     	}

		public UnityEngine.UI.Image EImage_InfoHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_InfoHeadImage == null )
     			{
		    		this.m_EImage_InfoHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/EImage_InfoHead");
     			}
     			return this.m_EImage_InfoHeadImage;
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
		    		this.m_ELabel_GoldCountText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/GoldRoot/ELabel_GoldCount");
     			}
     			return this.m_ELabel_GoldCountText;
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
		    		this.m_ELabel_DiamondCountText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/DiamondRoot/ELabel_DiamondCount");
     			}
     			return this.m_ELabel_DiamondCountText;
     		}
     	}

		public UnityEngine.UI.Image EImage_InfoPhotoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_InfoPhotoImage == null )
     			{
		    		this.m_EImage_InfoPhotoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EImage_RoleInfoRoot/EImage_InfoPhoto");
     			}
     			return this.m_EImage_InfoPhotoImage;
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
			this.m_EGBackGroundRectTransform = null;
			this.m_EImage_CreateRootImage = null;
			this.m_EButton_CreateRoleButton = null;
			this.m_EButton_CreateRoleImage = null;
			this.m_EInput_RoleNameInputField = null;
			this.m_EInput_RoleNameImage = null;
			this.m_EImage_RolePhotoImage = null;
			this.m_EButton_ChangePhotoButton = null;
			this.m_EButton_ChangePhotoImage = null;
			this.m_EImage_RoleHeadImage = null;
			this.m_EButton_ChangeHeadButton = null;
			this.m_EButton_ChangeHeadImage = null;
			this.m_EImage_RoleInfoRootImage = null;
			this.m_EButton_StartGameButton = null;
			this.m_EButton_StartGameImage = null;
			this.m_ELabel_RoleNameText = null;
			this.m_EImage_InfoHeadImage = null;
			this.m_ELabel_GoldCountText = null;
			this.m_ELabel_DiamondCountText = null;
			this.m_EImage_InfoPhotoImage = null;
			this.m_estipsui?.Dispose();
			this.m_estipsui = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Image m_EImage_CreateRootImage = null;
		private UnityEngine.UI.Button m_EButton_CreateRoleButton = null;
		private UnityEngine.UI.Image m_EButton_CreateRoleImage = null;
		private UnityEngine.UI.InputField m_EInput_RoleNameInputField = null;
		private UnityEngine.UI.Image m_EInput_RoleNameImage = null;
		private UnityEngine.UI.Image m_EImage_RolePhotoImage = null;
		private UnityEngine.UI.Button m_EButton_ChangePhotoButton = null;
		private UnityEngine.UI.Image m_EButton_ChangePhotoImage = null;
		private UnityEngine.UI.Image m_EImage_RoleHeadImage = null;
		private UnityEngine.UI.Button m_EButton_ChangeHeadButton = null;
		private UnityEngine.UI.Image m_EButton_ChangeHeadImage = null;
		private UnityEngine.UI.Image m_EImage_RoleInfoRootImage = null;
		private UnityEngine.UI.Button m_EButton_StartGameButton = null;
		private UnityEngine.UI.Image m_EButton_StartGameImage = null;
		private UnityEngine.UI.Text m_ELabel_RoleNameText = null;
		private UnityEngine.UI.Image m_EImage_InfoHeadImage = null;
		private UnityEngine.UI.Text m_ELabel_GoldCountText = null;
		private UnityEngine.UI.Text m_ELabel_DiamondCountText = null;
		private UnityEngine.UI.Image m_EImage_InfoPhotoImage = null;
		private ESTipsUI m_estipsui = null;
		public Transform uiTransform = null;
	}
}
