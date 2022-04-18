namespace ET
{
	public  class DlgOperate :Entity,IAwake,IUILogic
	{
		public ETCancellationToken token0 = new ETCancellationToken();
		public ETCancellationToken token1 = new ETCancellationToken();
		public ETCancellationToken token2 = new ETCancellationToken();
		public DlgOperateViewComponent View { get => this.Parent.GetComponent<DlgOperateViewComponent>();} 

		 

	}
}
