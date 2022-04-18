
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgFadeViewComponentAwakeSystem : AwakeSystem<DlgFadeViewComponent> 
	{
		public override void Awake(DlgFadeViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgFadeViewComponentDestroySystem : DestroySystem<DlgFadeViewComponent> 
	{
		public override void Destroy(DlgFadeViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
