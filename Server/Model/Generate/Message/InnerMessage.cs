using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(ObjectQueryResponse))]
	[Message(InnerOpcode.ObjectQueryRequest)]
	[ProtoContract]
	public partial class ObjectQueryRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long InstanceId { get; set; }

	}

	[ResponseType(nameof(A2M_Reload))]
	[Message(InnerOpcode.M2A_Reload)]
	[ProtoContract]
	public partial class M2A_Reload: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(InnerOpcode.A2M_Reload)]
	[ProtoContract]
	public partial class A2M_Reload: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2G_LockResponse))]
	[Message(InnerOpcode.G2G_LockRequest)]
	[ProtoContract]
	public partial class G2G_LockRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Address { get; set; }

	}

	[Message(InnerOpcode.G2G_LockResponse)]
	[ProtoContract]
	public partial class G2G_LockResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2G_LockReleaseResponse))]
	[Message(InnerOpcode.G2G_LockReleaseRequest)]
	[ProtoContract]
	public partial class G2G_LockReleaseRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Address { get; set; }

	}

	[Message(InnerOpcode.G2G_LockReleaseResponse)]
	[ProtoContract]
	public partial class G2G_LockReleaseResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectAddResponse))]
	[Message(InnerOpcode.ObjectAddRequest)]
	[ProtoContract]
	public partial class ObjectAddRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long InstanceId { get; set; }

	}

	[Message(InnerOpcode.ObjectAddResponse)]
	[ProtoContract]
	public partial class ObjectAddResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectLockResponse))]
	[Message(InnerOpcode.ObjectLockRequest)]
	[ProtoContract]
	public partial class ObjectLockRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long InstanceId { get; set; }

		[ProtoMember(3)]
		public int Time { get; set; }

	}

	[Message(InnerOpcode.ObjectLockResponse)]
	[ProtoContract]
	public partial class ObjectLockResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectUnLockResponse))]
	[Message(InnerOpcode.ObjectUnLockRequest)]
	[ProtoContract]
	public partial class ObjectUnLockRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long OldInstanceId { get; set; }

		[ProtoMember(3)]
		public long InstanceId { get; set; }

	}

	[Message(InnerOpcode.ObjectUnLockResponse)]
	[ProtoContract]
	public partial class ObjectUnLockResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectRemoveResponse))]
	[Message(InnerOpcode.ObjectRemoveRequest)]
	[ProtoContract]
	public partial class ObjectRemoveRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

	}

	[Message(InnerOpcode.ObjectRemoveResponse)]
	[ProtoContract]
	public partial class ObjectRemoveResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectGetResponse))]
	[Message(InnerOpcode.ObjectGetRequest)]
	[ProtoContract]
	public partial class ObjectGetRequest: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

	}

	[Message(InnerOpcode.ObjectGetResponse)]
	[ProtoContract]
	public partial class ObjectGetResponse: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long InstanceId { get; set; }

	}

	[ResponseType(nameof(G2R_GetLoginKey))]
	[Message(InnerOpcode.R2G_GetLoginKey)]
	[ProtoContract]
	public partial class R2G_GetLoginKey: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

	}

	[Message(InnerOpcode.G2R_GetLoginKey)]
	[ProtoContract]
	public partial class G2R_GetLoginKey: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long GateId { get; set; }

	}

	[Message(InnerOpcode.M2M_UnitTransferResponse)]
	[ProtoContract]
	public partial class M2M_UnitTransferResponse: Object, IActorResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long NewInstanceId { get; set; }

	}

	[Message(InnerOpcode.M2M_UnitLTransferResponse)]
	[ProtoContract]
	public partial class M2M_UnitLTransferResponse: Object, IActorResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long NewInstanceId { get; set; }

	}

	[Message(InnerOpcode.G2M_SessionDisconnect)]
	[ProtoContract]
	public partial class G2M_SessionDisconnect: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[ResponseType(nameof(L2A_RobGateSession))]
	[Message(InnerOpcode.A2L_RobGateSession)]
	[ProtoContract]
	public partial class A2L_RobGateSession: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

	}

	[Message(InnerOpcode.L2A_RobGateSession)]
	[ProtoContract]
	public partial class L2A_RobGateSession: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2L_DisConnectGateSession))]
	[Message(InnerOpcode.L2G_DisConnectGateSession)]
	[ProtoContract]
	public partial class L2G_DisConnectGateSession: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

	}

	[Message(InnerOpcode.G2L_DisConnectGateSession)]
	[ProtoContract]
	public partial class G2L_DisConnectGateSession: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2A_GetRealmKey))]
	[Message(InnerOpcode.A2R_GetRealmKey)]
	[ProtoContract]
	public partial class A2R_GetRealmKey: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

	}

	[Message(InnerOpcode.R2A_GetRealmKey)]
	[ProtoContract]
	public partial class R2A_GetRealmKey: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string RealmKey { get; set; }

	}

	[ResponseType(nameof(G2R_GetLoginGateKey))]
	[Message(InnerOpcode.R2G_GetLoginGateKey)]
	[ProtoContract]
	public partial class R2G_GetLoginGateKey: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

	}

	[Message(InnerOpcode.G2R_GetLoginGateKey)]
	[ProtoContract]
	public partial class G2R_GetLoginGateKey: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string GateSessionKey { get; set; }

	}

	[ResponseType(nameof(L2G_AddLoginRecord))]
	[Message(InnerOpcode.G2L_AddLoginRecord)]
	[ProtoContract]
	public partial class G2L_AddLoginRecord: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

	}

	[Message(InnerOpcode.L2G_AddLoginRecord)]
	[ProtoContract]
	public partial class L2G_AddLoginRecord: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(L2G_RemoveLoginRecord))]
	[Message(InnerOpcode.G2L_RemoveLoginRecord)]
	[ProtoContract]
	public partial class G2L_RemoveLoginRecord: Object, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

	}

	[Message(InnerOpcode.L2G_RemoveLoginRecord)]
	[ProtoContract]
	public partial class L2G_RemoveLoginRecord: Object, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2G_RequestEnterGameState))]
	[Message(InnerOpcode.G2M_RequestEnterGameState)]
	[ProtoContract]
	public partial class G2M_RequestEnterGameState: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(InnerOpcode.M2G_RequestEnterGameState)]
	[ProtoContract]
	public partial class M2G_RequestEnterGameState: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2G_RequestExitGame))]
	[Message(InnerOpcode.G2M_RequestExitGame)]
	[ProtoContract]
	public partial class G2M_RequestExitGame: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(InnerOpcode.M2G_RequestExitGame)]
	[ProtoContract]
	public partial class M2G_RequestExitGame: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

}
