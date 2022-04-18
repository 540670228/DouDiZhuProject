
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgLandlordsLoginViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.InputField EInput_AccountInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_AccountInputField == null )
     			{
		    		this.m_EInput_AccountInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Sprite_BackGround/Account_BackGround/EInput_Account");
     			}
     			return this.m_EInput_AccountInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_AccountImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_AccountImage == null )
     			{
		    		this.m_EInput_AccountImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Account_BackGround/EInput_Account");
     			}
     			return this.m_EInput_AccountImage;
     		}
     	}

		public UnityEngine.UI.InputField EInput_PasswordInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_PasswordInputField == null )
     			{
		    		this.m_EInput_PasswordInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Sprite_BackGround/Password_BackGround (1)/EInput_Password");
     			}
     			return this.m_EInput_PasswordInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_PasswordImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_PasswordImage == null )
     			{
		    		this.m_EInput_PasswordImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Password_BackGround (1)/EInput_Password");
     			}
     			return this.m_EInput_PasswordImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_EnterGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_EnterGameButton == null )
     			{
		    		this.m_EButton_EnterGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_EnterGame");
     			}
     			return this.m_EButton_EnterGameButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_EnterGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_EnterGameImage == null )
     			{
		    		this.m_EButton_EnterGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_EnterGame");
     			}
     			return this.m_EButton_EnterGameImage;
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
			this.m_EInput_AccountInputField = null;
			this.m_EInput_AccountImage = null;
			this.m_EInput_PasswordInputField = null;
			this.m_EInput_PasswordImage = null;
			this.m_EButton_EnterGameButton = null;
			this.m_EButton_EnterGameImage = null;
			this.m_estipsui?.Dispose();
			this.m_estipsui = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.InputField m_EInput_AccountInputField = null;
		private UnityEngine.UI.Image m_EInput_AccountImage = null;
		private UnityEngine.UI.InputField m_EInput_PasswordInputField = null;
		private UnityEngine.UI.Image m_EInput_PasswordImage = null;
		private UnityEngine.UI.Button m_EButton_EnterGameButton = null;
		private UnityEngine.UI.Image m_EButton_EnterGameImage = null;
		private ESTipsUI m_estipsui = null;
		public Transform uiTransform = null;
	}
}
