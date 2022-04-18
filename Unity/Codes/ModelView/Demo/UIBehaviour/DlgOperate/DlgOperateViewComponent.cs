
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgOperateViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text ELabel_PokerCount1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_PokerCount1Text == null )
     			{
		    		this.m_ELabel_PokerCount1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_PokerBack1/ELabel_PokerCount1");
     			}
     			return this.m_ELabel_PokerCount1Text;
     		}
     	}

		public UnityEngine.UI.Text ELabel_PokerCount2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_PokerCount2Text == null )
     			{
		    		this.m_ELabel_PokerCount2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/Image_PokerBack2/ELabel_PokerCount2");
     			}
     			return this.m_ELabel_PokerCount2Text;
     		}
     	}

		public UnityEngine.UI.Image ERoot_KeepPokerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoot_KeepPokerImage == null )
     			{
		    		this.m_ERoot_KeepPokerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_KeepPoker");
     			}
     			return this.m_ERoot_KeepPokerImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_KeepPoker0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_KeepPoker0Image == null )
     			{
		    		this.m_EImage_KeepPoker0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_KeepPoker/EImage_KeepPoker0");
     			}
     			return this.m_EImage_KeepPoker0Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_KeepPoker1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_KeepPoker1Image == null )
     			{
		    		this.m_EImage_KeepPoker1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_KeepPoker/EImage_KeepPoker1");
     			}
     			return this.m_EImage_KeepPoker1Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_KeepPoker2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_KeepPoker2Image == null )
     			{
		    		this.m_EImage_KeepPoker2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_KeepPoker/EImage_KeepPoker2");
     			}
     			return this.m_EImage_KeepPoker2Image;
     		}
     	}

		public UnityEngine.UI.Button EButton_YesButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_YesButtonButton == null )
     			{
		    		this.m_EButton_YesButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BK/EButton_YesButton");
     			}
     			return this.m_EButton_YesButtonButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_YesButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_YesButtonImage == null )
     			{
		    		this.m_EButton_YesButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/EButton_YesButton");
     			}
     			return this.m_EButton_YesButtonImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_YesTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_YesTextText == null )
     			{
		    		this.m_ELabel_YesTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/EButton_YesButton/ELabel_YesText");
     			}
     			return this.m_ELabel_YesTextText;
     		}
     	}

		public UnityEngine.UI.Button EButton_NoButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_NoButtonButton == null )
     			{
		    		this.m_EButton_NoButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BK/EButton_NoButton");
     			}
     			return this.m_EButton_NoButtonButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_NoButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_NoButtonImage == null )
     			{
		    		this.m_EButton_NoButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/EButton_NoButton");
     			}
     			return this.m_EButton_NoButtonImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_NoTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_NoTextText == null )
     			{
		    		this.m_ELabel_NoTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/EButton_NoButton/ELabel_NoText");
     			}
     			return this.m_ELabel_NoTextText;
     		}
     	}

		public UnityEngine.UI.Button EButton_PokerGoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_PokerGoButton == null )
     			{
		    		this.m_EButton_PokerGoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BK/EButton_PokerGo");
     			}
     			return this.m_EButton_PokerGoButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_PokerGoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_PokerGoImage == null )
     			{
		    		this.m_EButton_PokerGoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/EButton_PokerGo");
     			}
     			return this.m_EButton_PokerGoImage;
     		}
     	}

		public UnityEngine.UI.Image EImage_TalkInfo0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_TalkInfo0Image == null )
     			{
		    		this.m_EImage_TalkInfo0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_TipInfo/EImage_TalkInfo0");
     			}
     			return this.m_EImage_TalkInfo0Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_TalkInfo1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_TalkInfo1Image == null )
     			{
		    		this.m_EImage_TalkInfo1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_TipInfo/EImage_TalkInfo1");
     			}
     			return this.m_EImage_TalkInfo1Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_TalkInfo2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_TalkInfo2Image == null )
     			{
		    		this.m_EImage_TalkInfo2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_TipInfo/EImage_TalkInfo2");
     			}
     			return this.m_EImage_TalkInfo2Image;
     		}
     	}

		public UnityEngine.UI.Image EImage_ClockBK0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_ClockBK0Image == null )
     			{
		    		this.m_EImage_ClockBK0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_Clock/EImage_ClockBK0");
     			}
     			return this.m_EImage_ClockBK0Image;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TimerCount0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TimerCount0Text == null )
     			{
		    		this.m_ELabel_TimerCount0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/ERoot_Clock/EImage_ClockBK0/ELabel_TimerCount0");
     			}
     			return this.m_ELabel_TimerCount0Text;
     		}
     	}

		public UnityEngine.UI.Image EImage_ClockBK1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_ClockBK1Image == null )
     			{
		    		this.m_EImage_ClockBK1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_Clock/EImage_ClockBK1");
     			}
     			return this.m_EImage_ClockBK1Image;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TimerCount1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TimerCount1Text == null )
     			{
		    		this.m_ELabel_TimerCount1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/ERoot_Clock/EImage_ClockBK1/ELabel_TimerCount1");
     			}
     			return this.m_ELabel_TimerCount1Text;
     		}
     	}

		public UnityEngine.UI.Image EImage_ClockBK2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_ClockBK2Image == null )
     			{
		    		this.m_EImage_ClockBK2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_Clock/EImage_ClockBK2");
     			}
     			return this.m_EImage_ClockBK2Image;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TimerCount2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TimerCount2Text == null )
     			{
		    		this.m_ELabel_TimerCount2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BK/ERoot_Clock/EImage_ClockBK2/ELabel_TimerCount2");
     			}
     			return this.m_ELabel_TimerCount2Text;
     		}
     	}

		public UnityEngine.UI.Image ERoot_PokerSelfImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoot_PokerSelfImage == null )
     			{
		    		this.m_ERoot_PokerSelfImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_PokerSelf");
     			}
     			return this.m_ERoot_PokerSelfImage;
     		}
     	}

		public UnityEngine.UI.Image ERoot_Poker1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoot_Poker1Image == null )
     			{
		    		this.m_ERoot_Poker1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_Poker1");
     			}
     			return this.m_ERoot_Poker1Image;
     		}
     	}

		public UnityEngine.UI.Image ERoot_Poker2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoot_Poker2Image == null )
     			{
		    		this.m_ERoot_Poker2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_Poker2");
     			}
     			return this.m_ERoot_Poker2Image;
     		}
     	}

		public UnityEngine.UI.Image ERoot_Poker0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ERoot_Poker0Image == null )
     			{
		    		this.m_ERoot_Poker0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BK/ERoot_Poker0");
     			}
     			return this.m_ERoot_Poker0Image;
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
			this.m_ELabel_PokerCount1Text = null;
			this.m_ELabel_PokerCount2Text = null;
			this.m_ERoot_KeepPokerImage = null;
			this.m_EImage_KeepPoker0Image = null;
			this.m_EImage_KeepPoker1Image = null;
			this.m_EImage_KeepPoker2Image = null;
			this.m_EButton_YesButtonButton = null;
			this.m_EButton_YesButtonImage = null;
			this.m_ELabel_YesTextText = null;
			this.m_EButton_NoButtonButton = null;
			this.m_EButton_NoButtonImage = null;
			this.m_ELabel_NoTextText = null;
			this.m_EButton_PokerGoButton = null;
			this.m_EButton_PokerGoImage = null;
			this.m_EImage_TalkInfo0Image = null;
			this.m_EImage_TalkInfo1Image = null;
			this.m_EImage_TalkInfo2Image = null;
			this.m_EImage_ClockBK0Image = null;
			this.m_ELabel_TimerCount0Text = null;
			this.m_EImage_ClockBK1Image = null;
			this.m_ELabel_TimerCount1Text = null;
			this.m_EImage_ClockBK2Image = null;
			this.m_ELabel_TimerCount2Text = null;
			this.m_ERoot_PokerSelfImage = null;
			this.m_ERoot_Poker1Image = null;
			this.m_ERoot_Poker2Image = null;
			this.m_ERoot_Poker0Image = null;
			this.m_estipsui?.Dispose();
			this.m_estipsui = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ELabel_PokerCount1Text = null;
		private UnityEngine.UI.Text m_ELabel_PokerCount2Text = null;
		private UnityEngine.UI.Image m_ERoot_KeepPokerImage = null;
		private UnityEngine.UI.Image m_EImage_KeepPoker0Image = null;
		private UnityEngine.UI.Image m_EImage_KeepPoker1Image = null;
		private UnityEngine.UI.Image m_EImage_KeepPoker2Image = null;
		private UnityEngine.UI.Button m_EButton_YesButtonButton = null;
		private UnityEngine.UI.Image m_EButton_YesButtonImage = null;
		private UnityEngine.UI.Text m_ELabel_YesTextText = null;
		private UnityEngine.UI.Button m_EButton_NoButtonButton = null;
		private UnityEngine.UI.Image m_EButton_NoButtonImage = null;
		private UnityEngine.UI.Text m_ELabel_NoTextText = null;
		private UnityEngine.UI.Button m_EButton_PokerGoButton = null;
		private UnityEngine.UI.Image m_EButton_PokerGoImage = null;
		private UnityEngine.UI.Image m_EImage_TalkInfo0Image = null;
		private UnityEngine.UI.Image m_EImage_TalkInfo1Image = null;
		private UnityEngine.UI.Image m_EImage_TalkInfo2Image = null;
		private UnityEngine.UI.Image m_EImage_ClockBK0Image = null;
		private UnityEngine.UI.Text m_ELabel_TimerCount0Text = null;
		private UnityEngine.UI.Image m_EImage_ClockBK1Image = null;
		private UnityEngine.UI.Text m_ELabel_TimerCount1Text = null;
		private UnityEngine.UI.Image m_EImage_ClockBK2Image = null;
		private UnityEngine.UI.Text m_ELabel_TimerCount2Text = null;
		private UnityEngine.UI.Image m_ERoot_PokerSelfImage = null;
		private UnityEngine.UI.Image m_ERoot_Poker1Image = null;
		private UnityEngine.UI.Image m_ERoot_Poker2Image = null;
		private UnityEngine.UI.Image m_ERoot_Poker0Image = null;
		private ESTipsUI m_estipsui = null;
		public Transform uiTransform = null;
	}
}
