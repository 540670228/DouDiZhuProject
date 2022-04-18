
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgOperateViewComponentAwakeSystem : AwakeSystem<DlgOperateViewComponent> 
	{
		public override void Awake(DlgOperateViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgOperateViewComponentDestroySystem : DestroySystem<DlgOperateViewComponent> 
	{
		public override void Destroy(DlgOperateViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
