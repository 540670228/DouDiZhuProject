namespace ET
{
	public  class DlgResult :Entity,IAwake,IUILogic
	{

		public DlgResultViewComponent View { get => this.Parent.GetComponent<DlgResultViewComponent>();} 

		 

	}
}
