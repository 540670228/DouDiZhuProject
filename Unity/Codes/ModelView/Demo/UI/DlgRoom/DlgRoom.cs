namespace ET
{
	public  class DlgRoom :Entity,IAwake,IUILogic
	{

		public DlgRoomViewComponent View { get => this.Parent.GetComponent<DlgRoomViewComponent>();} 

		 

	}
}
