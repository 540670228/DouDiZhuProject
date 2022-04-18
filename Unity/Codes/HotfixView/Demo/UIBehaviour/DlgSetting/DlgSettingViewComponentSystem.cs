
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSettingViewComponentAwakeSystem : AwakeSystem<DlgSettingViewComponent> 
	{
		public override void Awake(DlgSettingViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSettingViewComponentDestroySystem : DestroySystem<DlgSettingViewComponent> 
	{
		public override void Destroy(DlgSettingViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
