
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESTipsUIAwakeSystem : AwakeSystem<ESTipsUI,Transform> 
	{
		public override void Awake(ESTipsUI self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	public static class ESTipsUISystem
	{
		
		public static void ShowTips(this ESTipsUI self, string content)
		{
			if (content == null) return;
			self.EImage_TipsBKImage.gameObject.SetActive(false);
			self.ELabel_TipsText.text = content;	
			self.EImage_TipsBKImage.gameObject.SetActive(true);
		}
	}
	
	[ObjectSystem]
	public class ESTipsUIDestroySystem : DestroySystem<ESTipsUI> 
	{
		public override void Destroy(ESTipsUI self)
		{
			self.DestroyWidget();
		}
	}
}
