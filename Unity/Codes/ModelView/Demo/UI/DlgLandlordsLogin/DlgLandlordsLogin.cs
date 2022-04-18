namespace ET
{
	public  class DlgLandlordsLogin :Entity,IAwake,IUILogic
	{

		public DlgLandlordsLoginViewComponent View { get => this.Parent.GetComponent<DlgLandlordsLoginViewComponent>();}
		
	}
}
