using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgRoomSystem
	{
		public static void RegisterUIEvent(this DlgRoom self)
		{
			self.View.EButton_ComeBackButton.AddListenerAsync(() =>
			{
				return self.OnComeBackClickHandler();
			});
			self.View.EButton_SetUpButton.AddListener(() =>
			{
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Setting);
			});
		}
		

		public static void ShowWindow(this DlgRoom self, Entity contextData = null)
		{
			//初始时默认将所有玩家及信息关闭
			self.View.EImage_Player0Image.gameObject.SetActive(false);
			self.View.EImage_Player1Image.gameObject.SetActive(false);
			self.View.EImage_Player2Image.gameObject.SetActive(false);
			//将匹配信息打开
			self.View.ELabel_MatchingNowText.gameObject.SetActive(true);
			//关闭所有地主标
			self.View.EImage_Logo0Image.gameObject.SetActive(false);
			self.View.EImage_Logo1Image.gameObject.SetActive(false);
			self.View.EImage_Logo2Image.gameObject.SetActive(false);
			
			//将返回按钮显示出来
			self.View.EButton_ComeBackButton.gameObject.SetActive(true);
			//播放激情背景音乐
			self.ZoneScene().GetComponent<AudiosComponent>().
					GetAudio(AudioType.BackGround_Audio).PlayMusic(ConstValue.BK_Exciting_Music);
			
		}

		public static void SetPlayer(this DlgRoom self, RoleInfo roleInfo,int index)
		{
			if (index == 0)
			{
				self.View.EImage_Player0Image.gameObject.SetActive(true);
				self.View.EImage_Player0Image.sprite = ResourceConfig.GetRolePhoto(roleInfo.PhotoSpriteName);
				self.View.ELabel_Name0Text.text = roleInfo.Name;
				self.View.ELabel_GoldCount0Text.text = roleInfo.goldCount.ToString();
			}
			else if (index == 1)
			{
				self.View.EImage_Player1Image.gameObject.SetActive(true);
				self.View.EImage_Player1Image.sprite = ResourceConfig.GetRolePhoto(roleInfo.PhotoSpriteName);
				self.View.ELabel_Name1Text.text = roleInfo.Name;
				self.View.ELabel_GoldCount1Text.text = roleInfo.goldCount.ToString();
			}
			else if (index == 2)
			{
				self.View.EImage_Player2Image.gameObject.SetActive(true);
				self.View.EImage_Player2Image.sprite = ResourceConfig.GetRolePhoto(roleInfo.PhotoSpriteName);
				self.View.ELabel_Name2Text.text = roleInfo.Name;
				self.View.ELabel_GoldCount2Text.text = roleInfo.goldCount.ToString();
			}
			
		}

		public static void SetLord(this DlgRoom self, int lordIndex)
		{
			switch (lordIndex)
			{
				case 0:
					self.View.EImage_Logo0Image.gameObject.SetActive(true);
					break;
				case 1:
					self.View.EImage_Logo1Image.gameObject.SetActive(true);
					break;
				case 2:
					self.View.EImage_Logo2Image.gameObject.SetActive(true);
					break;
			}
		}

		public static void RemovePlayer(this DlgRoom self, int index)
		{
			switch (index)
			{
				case 0:
					self.View.EImage_Player0Image.gameObject.SetActive(false);
					break;
				case 1:
					self.View.EImage_Player1Image.gameObject.SetActive(false);
					break;
				case 2:
					self.View.EImage_Player2Image.gameObject.SetActive(false);
					break;
			}
		}

		public static void SetMutiple(this DlgRoom self,int mutiple)
		{
			self.View.ELabel_MultipleText.text = mutiple.ToString();
		}

		public static void SetBasicScore(this DlgRoom self, int score)
		{
			self.View.ELabel_BasicScoreText.text = "底分："+score.ToString();
		}

		private async static ETTask OnComeBackClickHandler(this DlgRoom self)
		{
			C2M_UnitLComeOut c2MUnitLComeOut = new C2M_UnitLComeOut()
			{
				RoomId = self.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom.Id,
			};

			self.ZoneScene().GetComponent<SessionComponent>().Session.Send(c2MUnitLComeOut);
			
			//销毁客户端房间
			self.ZoneScene().GetComponent<PokerRoomComponent>().DeletePokerRoom();
			//关闭Room界面 回到Lobby界面
			self.ZoneScene().GetComponent<UIComponent>().
					GetDlgLogic<DlgFade>().StartFade(WindowID.WindowID_Room,WindowID.WindowID_LandlordsLobby);



			await ETTask.CompletedTask;
		}

		 

	}
}
