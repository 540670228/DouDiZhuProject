using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgOperateSystem
	{

		public static void RegisterUIEvent(this DlgOperate self)
		{
			
		}

		public static PokerViewsComponent GetPokerViewsComponent(this DlgOperate self)
		{
			return self.ZoneScene().GetComponent<PokerViewsComponent>();
		}
		
		public static Session GetSession(this DlgOperate self)
		{
			return self.ZoneScene().GetComponent<SessionComponent>().Session;
		}

		public static void ShowWindow(this DlgOperate self, Entity contextData = null)
		{
			//最初显示的界面
			self.InitWindow();
			//关闭room界面的匹配图标
			self.ZoneScene().GetComponent<UIComponent>().
					GetDlgLogic<DlgRoom>().View.ELabel_MatchingNowText.gameObject.SetActive(false);
			//关闭room的返回按钮
			self.ZoneScene().GetComponent<UIComponent>().
					GetDlgLogic<DlgRoom>().View.EButton_ComeBackButton.gameObject.SetActive(false);
		}

		public static void CloseAllInfo(this DlgOperate self)
		{
			self.View.EImage_TalkInfo0Image.gameObject.SetActive(false);
			self.View.EImage_TalkInfo1Image.gameObject.SetActive(false);
			self.View.EImage_TalkInfo2Image.gameObject.SetActive(false);
			
		}
		
		public static void SetTalkInfoImage(this DlgOperate self,string talkName,int index)
		{
			switch (index)
			{
				case 0:
					self.View.EImage_TalkInfo0Image.gameObject.SetActive(true);
					self.View.EImage_TalkInfo0Image.sprite = ResourceConfig.GetSprite(talkName);
					break;
				case 1:
					self.View.EImage_TalkInfo1Image.gameObject.SetActive(true);
					self.View.EImage_TalkInfo1Image.sprite = ResourceConfig.GetSprite(talkName);
					break;
				case 2:
					self.View.EImage_TalkInfo2Image.gameObject.SetActive(true);
					self.View.EImage_TalkInfo2Image.sprite = ResourceConfig.GetSprite(talkName);
					break;
			}
		}

		public static void SetOneInfoImage(this DlgOperate self, string talkName, int index, bool isClear = false)
		{
			self.View.EImage_TalkInfo0Image.gameObject.SetActive(false);
			self.View.EImage_TalkInfo0Image.gameObject.SetActive(false);
			self.View.EImage_TalkInfo0Image.gameObject.SetActive(false);
			switch (index)
			{
				case 0:
					self.View.EImage_TalkInfo0Image.gameObject.SetActive(true);
					self.View.EImage_TalkInfo0Image.sprite = ResourceConfig.GetSprite(talkName);
					break;
				case 1:
					self.View.EImage_TalkInfo1Image.gameObject.SetActive(true);
					self.View.EImage_TalkInfo1Image.sprite = ResourceConfig.GetSprite(talkName);
					break;
				case 2:
					self.View.EImage_TalkInfo2Image.gameObject.SetActive(true);
					self.View.EImage_TalkInfo2Image.sprite = ResourceConfig.GetSprite(talkName);
					break;
				default:
					break;
			}
		}

		public static void InitWindow(this DlgOperate self)
		{
			//开始时各个Info和按钮都无需显示
			self.View.EImage_TalkInfo0Image.gameObject.SetActive(false);
			self.View.EImage_TalkInfo1Image.gameObject.SetActive(false);
			self.View.EImage_TalkInfo2Image.gameObject.SetActive(false);
			self.View.EButton_YesButtonButton.gameObject.SetActive(false);
			self.View.EButton_PokerGoButton.gameObject.SetActive(false);
			self.View.EButton_NoButtonButton.gameObject.SetActive(false);

			//隐藏计时器
			self.View.EImage_ClockBK0Image.gameObject.SetActive(false);
			self.View.EImage_ClockBK1Image.gameObject.SetActive(false);
			self.View.EImage_ClockBK2Image.gameObject.SetActive(false);
			
			//背面显示17张牌
			self.View.ELabel_PokerCount1Text.text = "17";
			self.View.ELabel_PokerCount2Text.text = "17";
			
			self.InitKeepPoker();
			//禁用提示
			self.View.ESTipsUI.EImage_TipsBKImage.gameObject.SetActive(false);
		}

		public static void InitKeepPoker(this DlgOperate self)
		{
			//显示三张底牌 将其设置为底牌image
			self.View.ERoot_KeepPokerImage.gameObject.SetActive(true);
			//设置底牌的图片
			self.View.EImage_KeepPoker0Image.sprite = ResourceConfig.GetSprite(ConstValue.pokerBackName);
			self.View.EImage_KeepPoker1Image.sprite = ResourceConfig.GetSprite(ConstValue.pokerBackName);
			self.View.EImage_KeepPoker2Image.sprite = ResourceConfig.GetSprite(ConstValue.pokerBackName);
		}

		public static void SetKeepPoker(this DlgOperate self,List<Poker> pokerList)
		{
			self.View.EImage_KeepPoker0Image.sprite = ResourceConfig.GetSprite(pokerList[0].pokerName);
			self.View.EImage_KeepPoker1Image.sprite = ResourceConfig.GetSprite(pokerList[1].pokerName);
			self.View.EImage_KeepPoker2Image.sprite = ResourceConfig.GetSprite(pokerList[2].pokerName);
		}

		public static void SetBackCount(this DlgOperate self, int index, int count)
		{
			if (index == 1)
			{
				self.View.ELabel_PokerCount1Text.text = count.ToString();
			}
			else if (index == 2)
			{
				self.View.ELabel_PokerCount2Text.text = count.ToString();
			}
		}
		
		public static Transform GetSelfViewRoot(this DlgOperate self)
		{
			return self.View.ERoot_PokerSelfImage.transform;
		}

		public static Transform GetViewRoot(this DlgOperate self, int index)
		{
			switch (index)
			{
				case 0:
					return self.View.ERoot_Poker0Image.transform;
				case 1:
					return self.View.ERoot_Poker1Image.transform;
				case 2:
					return self.View.ERoot_Poker2Image.transform;
			}

			return null;
		}

		public static void CloseAllTimeDown(this DlgOperate self)
		{
			self.token0.Cancel();
			self.token1.Cancel();
			self.token2.Cancel();
		}
		
		public static void SetTimeDown(this DlgOperate self, int index,Action action = null)
		{
			//同时只能有一个计时器 先停掉全部的计时器
			self.token0.Cancel();
			self.token1.Cancel();
			self.token2.Cancel();
			self.View.EImage_ClockBK0Image.gameObject.SetActive(false);
			self.View.EImage_ClockBK1Image.gameObject.SetActive(false);
			self.View.EImage_ClockBK2Image.gameObject.SetActive(false);
			switch (index)
			{
				case 0:
					self.View.EImage_ClockBK0Image.gameObject.SetActive(true);
					self.token0 = new ETCancellationToken();
					TimeCountDown.startCountDown
							(self.View.ELabel_TimerCount0Text, ConstValue.countDownTime,self.token0,action).Coroutine();
					break;
				case 1:
					self.View.EImage_ClockBK1Image.gameObject.SetActive(true);
					self.token1 = new ETCancellationToken();
					TimeCountDown.startCountDown
							(self.View.ELabel_TimerCount1Text, ConstValue.countDownTime,self.token1,action).Coroutine();
					break;
				case 2:
					self.View.EImage_ClockBK2Image.gameObject.SetActive(true);
					self.token2 = new ETCancellationToken();
					TimeCountDown.startCountDown
							(self.View.ELabel_TimerCount2Text, ConstValue.countDownTime,self.token2,action).Coroutine();
					break;
			}
		}
		
		//设置叫地主环节
		public static void SetCallLord(this DlgOperate self,int lordIndex)
		{
			//弹出指定Index的计时器
			//如果自己是地主 则显示按钮
			switch (lordIndex)
			{
				case 0:
					//显示相应按钮
					self.View.EButton_YesButtonButton.gameObject.SetActive(true);
					self.View.EButton_NoButtonButton.gameObject.SetActive(true);
					self.View.ELabel_YesTextText.text = "叫地主";
					self.View.ELabel_NoTextText.text = "不叫";
					//注册相应事件 注册前会自动删除其它
					self.View.EButton_YesButtonButton.AddListener(() =>
					{
						self.GetSession().Send(new C2M_CallLordResult()
						{
							isCall = true,
						});
						//InfoUI的显示
						self.SetTalkInfoImage(ConstValue.callYesInfoName,0);
					});
					self.View.EButton_NoButtonButton.AddListener(() =>
					{
						self.GetSession().Send(new C2M_CallLordResult()
						{
							isCall = false,
						});
						self.SetTalkInfoImage(ConstValue.callNoInfoName,0);
					});
					//TODO:倒计时逻辑 客户端下即可倒计时结束后仍未响应则自动响应事件
					self.SetTimeDown(0, () =>
					{
						//模拟按下NoButton
						self.View.EButton_NoButtonButton.onClick.Invoke();
					});
					break;
				case 1:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(1);
					break;
				case 2:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(2);
					break;
			}
			
		}
		
		//设置抢地主环节
		public static void SetRobLord(this DlgOperate self, int robIndex)
		{
			switch (robIndex)
			{
				case 0:
					//显示相应按钮
					self.View.EButton_YesButtonButton.gameObject.SetActive(true);
					self.View.EButton_NoButtonButton.gameObject.SetActive(true);
					self.View.ELabel_YesTextText.text = "抢地主";
					self.View.ELabel_NoTextText.text = "不抢";
					//注册相应事件 注册前会自动删除其它
					self.View.EButton_YesButtonButton.AddListener(() =>
					{
						self.GetSession().Send(new C2M_RobLordResult()
						{
							isRob = true,
						});
						//InfoUI的显示
						self.SetTalkInfoImage(ConstValue.robYesInfoName,0);
					});
					self.View.EButton_NoButtonButton.AddListener(() =>
					{
						self.GetSession().Send(new C2M_RobLordResult()
						{
							isRob = false,
						});
						self.SetTalkInfoImage(ConstValue.robNoInfoName,0);
					});
					//TODO:倒计时逻辑 客户端下即可倒计时结束后仍未响应则自动响应事件
					self.SetTimeDown(0, () =>
					{
						//模拟按下NoButton
						self.View.EButton_NoButtonButton.onClick.Invoke();
					});
					break;
				case 1:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(1);
					break;
				case 2:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(2);
					break;
			}
		}

		public static void SetAddLord(this DlgOperate self, int addIndex)
		{
			switch (addIndex)
			{
				case 0:
					//显示相应按钮
					self.View.EButton_YesButtonButton.gameObject.SetActive(true);
					self.View.EButton_NoButtonButton.gameObject.SetActive(true);
					self.View.ELabel_YesTextText.text = "加倍";
					self.View.ELabel_NoTextText.text = "不加倍";
					//注册相应事件 注册前会自动删除其它
					self.View.EButton_YesButtonButton.AddListener(() =>
					{
						self.GetSession().Send(new C2M_AddLordResult()
						{
							isAdd = true,
						});
						//InfoUI的显示
						self.SetTalkInfoImage(ConstValue.addYesInfoName,0);
					});
					self.View.EButton_NoButtonButton.AddListener(() =>
					{
						self.GetSession().Send(new C2M_AddLordResult()
						{
							isAdd = false,
						});
						self.SetTalkInfoImage(ConstValue.addNoInfoName,0);
					});
					//倒计时逻辑 客户端下即可倒计时结束后仍未响应则自动响应事件
					self.SetTimeDown(0, () =>
					{
						//模拟按下NoButton
						self.View.EButton_NoButtonButton.onClick.Invoke();
					});
					break;
				case 1:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(1);
					break;
				case 2:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(2);
					break;
			}
		}

		public static void SetFirstRound(this DlgOperate self, int lordIndex)
		{
			switch (lordIndex)
			{
				case 0:
					//显示相应按钮
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					self.View.EButton_PokerGoButton.gameObject.SetActive(true);
					//注册相应事件 注册前会自动删除其它
					self.View.EButton_PokerGoButton.AddListener(() =>
					{
						self.GetPokerViewsComponent().PokerGo();
					});
					//倒计时逻辑 客户端下即可倒计时结束后仍未响应则自动响应事件
					self.SetTimeDown(0, () =>
					{
						//恢复所有已经选中的牌
						self.GetPokerViewsComponent().CancelAllSelect();
						//选中最小的牌
						self.GetPokerViewsComponent().selfPokerViewList[0].SetPokerViewState(PokerViewState.Prepare);
						//加入select集合
						self.GetPokerViewsComponent().selectPokerViewList.Add(self.GetPokerViewsComponent().selfPokerViewList[0]);
						//PokerGO
						self.GetPokerViewsComponent().PokerGo();
					});
					break;
				case 1:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(1);
					break;
				case 2:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(2);
					break;
			}
		}

		public static void SetNormalRound(this DlgOperate self, int outIndex,List<Poker> pokers,PokerListType plType)
		{
			switch (outIndex)
			{
				case 0:
					//显示相应按钮
					self.View.EButton_YesButtonButton.gameObject.SetActive(true);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					self.View.EButton_PokerGoButton.gameObject.SetActive(true);
					self.View.ELabel_YesTextText.text = "不出";
					//注册相应事件 注册前会自动删除其它
					self.View.EButton_PokerGoButton.AddListener(() =>
					{
						self.CloseAllTimeDown();
						self.GetPokerViewsComponent().PokerExamineGo(pokers,plType);
						//self.ZoneScene().GetComponent<AudiosComponent>().
								//GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_dani_Music + self.GetSuffix());
					});
					self.View.EButton_YesButtonButton.AddListener(() =>
					{
						self.GetPokerViewsComponent().OutNo(pokers,plType);
						//设置info
						self.SetOneInfoImage(ConstValue.outNo,0);
					});
					//倒计时逻辑 客户端下即可倒计时结束后仍未响应则自动响应事件
					self.SetTimeDown(0, () =>
					{
						self.CloseAllTimeDown();
						//模拟按下不出按钮
						self.View.EButton_YesButtonButton.onClick.Invoke();
					});
					//特判王炸 没有出牌键 并加以提示
					if (plType == PokerListType.BigBoom)
					{
						self.View.EButton_PokerGoButton.gameObject.SetActive(false);
						self.View.ESTipsUI.ShowTips("您没有能大于王炸的牌");
					}

					break;
				case 1:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					self.View.EButton_PokerGoButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(1);
					break;
				case 2:
					self.View.EButton_YesButtonButton.gameObject.SetActive(false);
					self.View.EButton_NoButtonButton.gameObject.SetActive(false);
					self.View.EButton_PokerGoButton.gameObject.SetActive(false);
					//倒计时动画
					self.SetTimeDown(2);
					break;
			}
		}

		public static string GetSuffix(this DlgOperate self)
		{
			Sex sex = self.DomainScene().GetComponent<MyUnitLComponent>().unitL.roleInfo.getSex();
			string suffix = sex == Sex.boy? "_boy" : "_girl";
			return suffix;
		}
	}
}
