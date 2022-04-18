using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static class DlgLandlordsLobbySystem
	{
		public static void RegisterUIEvent(this DlgLandlordsLobby self)
		{
			Log.Debug("注册匹配事件");
			//匹配按钮
			self.View.EButton_MatchingButton.AddListenerAsync(() =>
			{
				try
				{
					Log.Debug("点击匹配按钮");
					return self.OnMatchingPlayerClickHandler();
				}
				catch (Exception e)
				{
					Log.Error(e.ToString());
					throw;
				}
			});
			Log.Debug("匹配事件注册成功");

			//设置按钮
			self.View.EButton_SetUpButton.AddListener(() =>
			{
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Setting);
			});
			
			//积分榜
			self.View.EButton_ScoreTitleButton.AddListener(() => {});
			
			//金钱榜
			self.View.EButton_GoldTitleButton.AddListener(()=>{});
			
			//充值金币
			self.View.EButton_AddGoldButton.AddListener(()=>{});
			
			//充值砖石
			self.View.EButton_AddDiamondButton.AddListener(()=>{});
		}

		public static void ShowWindow(this DlgLandlordsLobby self, Entity contextData = null)
		{
			//UI界面的初始化
			self.InitRoleUI();
			//禁用提示
			self.View.ESTipsUI.EImage_TipsBKImage.gameObject.SetActive(false);
			//开启播放Normal背景音乐
			self.ZoneScene().GetComponent<AudiosComponent>().
					GetAudio(AudioType.BackGround_Audio).PlayMusic(ConstValue.BK_NORMAL_MUSIC);
		}
		
		//初始化角色信息到界面中
		private static void InitRoleUI(this DlgLandlordsLobby self)
		{
			try
			{
				RoleInfo roleInfo = self.ZoneScene().GetComponent<RoleInfoComponent>().roleInfo;
				if (roleInfo == null)
				{
					Log.Error("角色信息为空");
					return;
				}
				//初始化头像 姓名 砖石 Gold
				self.View.EImage_RoleHeadImage.sprite = ResourceConfig.GetRoleHead(roleInfo.HeadSpriteName);
				self.View.ELabel_RoleNameText.text = roleInfo.Name;
				self.View.ELabel_DiamondCountText.text = roleInfo.diamond.ToString();
				self.View.ELabel_GoldCountText.text = roleInfo.goldCount.ToString();
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				throw;
			}
			
			
		}


		public static void SetLevelValue(this DlgLandlordsLobby self,float value)
		{
			Slider slider = self.View.E_LevelSlider.gameObject.GetComponent<Slider>();
			slider.value = value;
		}

		public async static ETTask OnMatchingPlayerClickHandler(this DlgLandlordsLobby self)
		{
			Log.Debug("开始进行匹配");
			//显示房间界面
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Room);
			//发送开始匹配消息
			M2C_StartMatching res =  
					await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(new C2M_StartMatching()) as M2C_StartMatching;
			if (res.Error != ErrorCode.ERR_Success)
			{
				Log.Error(res.Error.ToString());
				return;
			}
			//关闭大厅界面
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_LandlordsLobby);

			await ETTask.CompletedTask;
		}

		 

	}
}
