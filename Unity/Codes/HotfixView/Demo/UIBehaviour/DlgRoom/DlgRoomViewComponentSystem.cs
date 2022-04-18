
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgRoomViewComponentAwakeSystem : AwakeSystem<DlgRoomViewComponent> 
	{
		public override void Awake(DlgRoomViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgRoomViewComponentDestroySystem : DestroySystem<DlgRoomViewComponent> 
	{
		public override void Destroy(DlgRoomViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
