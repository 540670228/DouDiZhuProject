namespace ET
{
	public  class DlgFade :Entity,IAwake,IUILogic
	{

		public DlgFadeViewComponent View { get => this.Parent.GetComponent<DlgFadeViewComponent>();} 

		 

	}
}
