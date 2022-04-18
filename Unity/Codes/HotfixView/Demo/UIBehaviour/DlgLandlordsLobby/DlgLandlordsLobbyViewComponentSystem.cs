
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgLandlordsLobbyViewComponentAwakeSystem : AwakeSystem<DlgLandlordsLobbyViewComponent> 
	{
		public override void Awake(DlgLandlordsLobbyViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgLandlordsLobbyViewComponentDestroySystem : DestroySystem<DlgLandlordsLobbyViewComponent> 
	{
		public override void Destroy(DlgLandlordsLobbyViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
