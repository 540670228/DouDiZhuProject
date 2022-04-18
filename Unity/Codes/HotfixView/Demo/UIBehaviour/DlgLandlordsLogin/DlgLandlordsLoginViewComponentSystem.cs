
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgLandlordsLoginViewComponentAwakeSystem : AwakeSystem<DlgLandlordsLoginViewComponent> 
	{
		public override void Awake(DlgLandlordsLoginViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgLandlordsLoginViewComponentDestroySystem : DestroySystem<DlgLandlordsLoginViewComponent> 
	{
		public override void Destroy(DlgLandlordsLoginViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
