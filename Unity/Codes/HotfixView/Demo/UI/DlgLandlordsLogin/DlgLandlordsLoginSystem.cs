using System.Text.RegularExpressions;


namespace ET
{
	public static class DlgLandlordsLoginSystem
	{

		public static void RegisterUIEvent(this DlgLandlordsLogin self)
		{
			self.View.EButton_EnterGameButton.AddListenerAsync(()=>
			{
				return self.OnEnterGameClickHandler();
			});
		}

		private async static ETTask OnEnterGameClickHandler(this DlgLandlordsLogin self)
		{
			//播放UI音效
			self.ZoneScene().GetComponent<AudiosComponent>().
					GetAudio(AudioType.UI_Audio).PlayMusic(ConstValue.CLIP_UINORMAL);

			
			//验证密码格式   账号多于6位即可  密码6位必须包含大小写字母
			Regex pswRegex = new Regex(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,30}");
			string accountName = self.View.EInput_AccountInputField.text;
			string passWord = self.View.EInput_PasswordInputField.text;
			if (accountName.Length < 6 ||
			    !pswRegex.IsMatch(passWord))
			{
				//TODO:弹窗提醒
				//将上一次的禁用 更新UI 显示出来
				self.View.ESTipsUI.ShowTips(ErrorCodeHelper.GetErrorInfo(ErrorCode.ERR_AccountFormatError));
				return;
			}

			
			int errorCode = await LoginSystem.Login(self.ZoneScene(), ConstValue.LoginAddress, accountName, passWord);
			if (errorCode == ErrorCode.ERR_Success)
			{
				self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgFade>().
						StartFade(WindowID.WindowID_LandlordsLogin,WindowID.WindowID_Roles);
			}
			else
			{
				//如果不成功则返回
				self.View.ESTipsUI.ShowTips(ErrorCodeHelper.GetErrorInfo(errorCode));
				return;
			}
			
			
			await ETTask.CompletedTask;
		}

		public static void ShowWindow(this DlgLandlordsLogin self, Entity contextData = null)
		{
			//禁用物体
			self.View.ESTipsUI.EImage_TipsBKImage.gameObject.SetActive(false);
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Fade);
		}

		 

	}
}
