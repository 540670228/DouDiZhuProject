using System.Collections;
using System.Collections.Generic;
using System;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgRolesSystem
	{
		private static int currentPhotoId = 0;
		private static int currentHeadId = 0;
		public static void RegisterUIEvent(this DlgRoles self)
		{
			self.View.EButton_ChangeHeadButton.AddListener(() =>
			{
				currentHeadId = (currentHeadId + 1) % ResourceConfig.headCount;
				self.SetHeadImage();
			});
			
			self.View.EButton_ChangePhotoButton.AddListener(() =>
			{
				
				currentPhotoId = (currentPhotoId + 1) % ResourceConfig.photoCount;
				self.SetPhotoImage();
			});
			
			self.View.EButton_StartGameButton.AddListenerAsync(() =>
			{
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.UI_Audio).PlayMusic(ConstValue.CLIP_UINORMAL);
				return self.OnStartGameClickHandler();
			});
			
			self.View.EButton_CreateRoleButton.AddListenerAsync(() =>
			{
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.UI_Audio).PlayMusic(ConstValue.CLIP_UINORMAL);
				return self.OnCreateRoleClickHandler();
			});
		}

		public async static void ShowWindow(this DlgRoles self, Entity contextData = null)
		{
			//先判断是否已经存在角色
			await LoginSystem.GetRoleInfo(self.ZoneScene());
			RoleInfo roleInfo = self.ZoneScene().GetComponent<RoleInfoComponent>().roleInfo;
			if (roleInfo == null)
			{
				//初始化头像和形象
				self.SetHeadImage();
				self.SetPhotoImage();
				self.View.EImage_RoleInfoRootImage.gameObject.SetActive(false);
			}
			else
			{
				self.SetRoleInfo(roleInfo);
			}
			//播放Welcome背景音乐
			self.ZoneScene().GetComponent<AudiosComponent>().
					GetAudio(AudioType.BackGround_Audio).PlayMusic(ConstValue.BK_WELCOME_MUSIC);
		}

		public static void SetHeadImage(this DlgRoles self)
		{
			self.View.EImage_RoleHeadImage.sprite = 
					ResourceConfig.GetRoleHead(ConstValue.roleHeadPrefix + currentHeadId);
		}

		public static void SetPhotoImage(this DlgRoles self)
		{
			self.View.EImage_RolePhotoImage.sprite = 
					ResourceConfig.GetRolePhoto(ConstValue.rolePhotoPrefix + currentPhotoId);
		}

		private async static ETTask OnStartGameClickHandler(this DlgRoles self)
		{
			
			self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgFade>().
					StartFade(WindowID.WindowID_Roles,WindowID.WindowID_LandlordsLobby);
			int errorCode = await LoginSystem.GetRealmKey(self.ZoneScene());
			if (errorCode != ErrorCode.ERR_Success)
			{
				Log.Error(errorCode.ToString());
				return;
			}
			errorCode = await LoginSystem.EnterGame(self.ZoneScene());
			if (errorCode != ErrorCode.ERR_Success)
			{
				Log.Error(errorCode.ToString());
				return;
			}

		}

		private async static ETTask OnCreateRoleClickHandler(this DlgRoles self)
		{
			string roleName = self.View.EInput_RoleNameInputField.text;
			string headName = ConstValue.roleHeadPrefix + currentHeadId;
			string charName = ConstValue.rolePhotoPrefix + currentPhotoId;
			if (string.IsNullOrEmpty(roleName))
			{
				self.View.ESTipsUI.ShowTips(ErrorCodeHelper.GetErrorInfo(ErrorCode.ERR_RoleNameIsNull));
			}

			int errorCode = await LoginSystem.CreateRoleInfo(self.ZoneScene(),roleName,headName,charName);
			if (errorCode != ErrorCode.ERR_Success)
			{
				self.View.ESTipsUI.ShowTips(ErrorCodeHelper.GetErrorInfo(errorCode));
				return;
			}
			
			self.SetRoleInfo(self.ZoneScene().GetComponent<RoleInfoComponent>().roleInfo);
		}

		private static void SetRoleInfo(this DlgRoles self,RoleInfo info)
		{
			self.View.EImage_InfoHeadImage.sprite = ResourceConfig.GetRoleHead(info.HeadSpriteName);
			Log.Debug("设置人物形象"+info.PhotoSpriteName);
			self.View.EImage_InfoPhotoImage.sprite = ResourceConfig.GetRolePhoto(info.PhotoSpriteName);
			self.View.ELabel_RoleNameText.text = info.Name;
			self.View.ELabel_GoldCountText.text = info.goldCount.ToString();
			self.View.ELabel_DiamondCountText.text = info.diamond.ToString();
			//禁用Create界面 开启Info界面
			self.View.EImage_CreateRootImage.gameObject.SetActive(false);
			self.View.EImage_RoleInfoRootImage.gameObject.SetActive(true);
		}

	}
}
