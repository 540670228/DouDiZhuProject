namespace ET
{
	public static class SessionPlayerComponentSystem
	{
		public class SessionPlayerComponentDestroySystem: DestroySystem<SessionPlayerComponent>
		{
			public async override void Destroy(SessionPlayerComponent self)
			{
				Player player = Game.EventSystem.Get(self.PlayerInstanceId) as Player;
				//直接踢下线
				await DisConnectHelper.KickPlayer(player);

				//TODO:当gateSession释放KickPlayer一定会运行无法实现顶号复用 需要解决
				
				await ETTask.CompletedTask;
			}
		}

		public static Player GetMyPlayer(this SessionPlayerComponent self)
		{
			return self.Domain.GetComponent<PlayerComponent>().Get(self.PlayerInstanceId);
		}
	}
}
