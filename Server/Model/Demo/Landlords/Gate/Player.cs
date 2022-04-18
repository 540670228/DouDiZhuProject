using MongoDB.Driver.Core.Events;

namespace ET
{
	public enum PlayerState
	{
		DisConnect,
		Gate,
		Game,
	}
	
	[ObjectSystem]
	public class PlayerSystem : AwakeSystem<Player, long , long>
	{
		public override void Awake(Player self, long accountId,long sessionInstanceId)
		{
			self.AccountId = accountId;
			self.SessionInstanceId = sessionInstanceId;
		}
	}

	public sealed class Player : Entity, IAwake<long,long>
	{
		//账户Id
		public long AccountId { get; set; }
		
		//Unit映射对象
		
		public long UnitId { get; set; }
		
		//网关Session ActorId
		public long SessionInstanceId { get; set; }

		public PlayerState playerState;



	}
}