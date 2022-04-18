using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgResultSystem
	{
		public static DlgLandlordsLobby GetDlgLobby(this DlgResult self)
		{
			return self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgLandlordsLobby>();
		}
		public static DlgFade GetDlgFade(this DlgResult self)
		{
			return self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgFade>();
		}

		public static void RegisterUIEvent(this DlgResult self)
		{
			//继续游戏
			self.View.EButton_ContinueButton.AddListenerAsync(() =>
			{
				return self.onContinueGameClickHandler();
			});
			
			//回到主界面
			self.View.EButton_ComeBackButton.AddListener(() =>
			{
				//直接关闭room和operate窗口回到主界面即可
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Room);
				
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Operate);
				
				self.GetDlgFade().StartFade(WindowID.WindowID_Result,WindowID.WindowID_LandlordsLobby);
			});
		}

		private async static ETTask onContinueGameClickHandler(this DlgResult self)
		{
			//关闭Result和Operate画面
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Operate);
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Result);
			//发送匹配信息
			await self.GetDlgLobby().OnMatchingPlayerClickHandler();
			
		}

		public static void ShowWindow(this DlgResult self, Entity contextData = null)
		{
			self.InitWindow();
		}

		public static void SetResultInfo(this DlgResult self,List<ResultInfo> resList,long WinId)
		{
			self.InitWindow();
			PokerRoom room = self.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
			UnitL me = self.ZoneScene().GetComponent<MyUnitLComponent>().unitL;
			bool isWin = me.Id == WinId;
			self.SetResultImage(isWin);

			self.SetMyInfo();
			for (int i = 0; i < resList.Count; i++)
			{
				bool isLord = resList[i].UnitLId == room.lordId;
				self.SetPlayerResInfo(i,resList[i].name,resList[i].deltaGold,isLord);
			}

		}

		public static void InitWindow(this DlgResult self)
		{
			//关闭所有的地主图标
			self.View.EImage_Lord0Image.gameObject.SetActive(false);
			self.View.EImage_Lord1Image.gameObject.SetActive(false);
			self.View.EImage_Lord2Image.gameObject.SetActive(false);
		}

		public static void SetResultImage(this DlgResult self,bool isWin)
		{
			string name = isWin? ConstValue.winImage : ConstValue.failImage;
			self.View.EImage_ResultImage.sprite = ResourceConfig.GetSprite(name);
		}

		public static void SetMyInfo(this DlgResult self)
		{
			RoleInfo roleInfo = self.ZoneScene().GetComponent<RoleInfoComponent>().roleInfo;
			self.View.EImage_PlayerImage.sprite = ResourceConfig.GetRolePhoto(roleInfo.PhotoSpriteName);
			self.View.EImage_HeadImage.sprite = ResourceConfig.GetRoleHead(roleInfo.HeadSpriteName);
		}

		public static void SetPlayerResInfo(this DlgResult self, int index,string name,int deltaCount,bool isLord)
		{
			PokerRoom room = self.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
			switch (index)
			{
				case 0:
					if(isLord) self.View.EImage_Lord0Image.gameObject.SetActive(true);
					self.View.ELabel_Name0Text.text = name;
					self.View.ELabel_GoldDelta0Text.text = deltaCount.ToString();
					self.View.ELabel_Mutiple0Text.text = room.mutiple.ToString();
					self.View.ELabel_BasicCore0Text.text = room.basicScore.ToString();
					break;
				case 1:
					if(isLord) self.View.EImage_Lord1Image.gameObject.SetActive(true);
					self.View.ELabel_Name1Text.text = name;
					self.View.ELabel_GoldDelta1Text.text = deltaCount.ToString();
					self.View.ELabel_Mutiple1Text.text = room.mutiple.ToString();
					self.View.ELabel_BasicCore1Text.text = room.basicScore.ToString();
					break;
				case 2:
					if(isLord) self.View.EImage_Lord2Image.gameObject.SetActive(true);
					self.View.ELabel_Name2Text.text = name;
					self.View.ELabel_GoldDelta2Text.text = deltaCount.ToString();
					self.View.ELabel_Mutiple2Text.text = room.mutiple.ToString();
					self.View.ELabel_BasicCore2Text.text = room.basicScore.ToString();
					break;
			}
		}



	}
}
