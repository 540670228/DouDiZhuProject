using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgSettingSystem
	{

		public static void RegisterUIEvent(this DlgSetting self)
		{
			self.View.EButton_OKButton.AddListener(() =>
			{
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Setting);
			});
			self.View.EGToggle_EffectRectTransform.GetComponent<Toggle>().onValueChanged.AddListener((state) =>
			{
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.Effect_Audio).SetVolumeState(state);
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.Operate_Audio).SetVolumeState(state);
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.UI_Audio).SetVolumeState(state);
			});
			self.View.EGToggle_VolumeRectTransform.GetComponent<Toggle>().onValueChanged.AddListener((state) =>
			{
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.BackGround_Audio).SetVolumeState(state);
			});
			self.View.EGSlider_VolumeValueRectTransform.GetComponent<Slider>().onValueChanged.AddListener((value) =>
			{
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.BackGround_Audio).SetVolumeValue(value);
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.Effect_Audio).SetVolumeValue(value);
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.Operate_Audio).SetVolumeValue(value);
				self.ZoneScene().GetComponent<AudiosComponent>().
						GetAudio(AudioType.UI_Audio).SetVolumeValue(value);
			});
		}
		

		public static void ShowWindow(this DlgSetting self, Entity contextData = null)
		{
			float value = self.ZoneScene().GetComponent<AudiosComponent>().GetAudio(AudioType.BackGround_Audio).GetAudio().volume;
			//初始化音量按钮
			self.View.EGSlider_VolumeValueRectTransform.GetComponent<Slider>().value = value;
		}

		 

	}
}
