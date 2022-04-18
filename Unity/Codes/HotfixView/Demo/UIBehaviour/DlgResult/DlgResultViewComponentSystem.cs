
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgResultViewComponentAwakeSystem : AwakeSystem<DlgResultViewComponent> 
	{
		public override void Awake(DlgResultViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgResultViewComponentDestroySystem : DestroySystem<DlgResultViewComponent> 
	{
		public override void Destroy(DlgResultViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
