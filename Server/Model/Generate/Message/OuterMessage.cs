using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string response { get; set; }

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

// 自己unitId
		[ProtoMember(4)]
		public long MyId { get; set; }

	}

	[Message(OuterOpcode.MoveInfo)]
	[ProtoContract]
	public partial class MoveInfo: Object
	{
		[ProtoMember(1)]
		public List<float> X = new List<float>();

		[ProtoMember(2)]
		public List<float> Y = new List<float>();

		[ProtoMember(3)]
		public List<float> Z = new List<float>();

		[ProtoMember(4)]
		public float A { get; set; }

		[ProtoMember(5)]
		public float B { get; set; }

		[ProtoMember(6)]
		public float C { get; set; }

		[ProtoMember(7)]
		public float W { get; set; }

		[ProtoMember(8)]
		public int TurnSpeed { get; set; }

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public int Type { get; set; }

		[ProtoMember(4)]
		public float X { get; set; }

		[ProtoMember(5)]
		public float Y { get; set; }

		[ProtoMember(6)]
		public float Z { get; set; }

		[ProtoMember(7)]
		public float ForwardX { get; set; }

		[ProtoMember(8)]
		public float ForwardY { get; set; }

		[ProtoMember(9)]
		public float ForwardZ { get; set; }

		[ProtoMember(10)]
		public List<int> Ks = new List<int>();

		[ProtoMember(11)]
		public List<long> Vs = new List<long>();

		[ProtoMember(12)]
		public MoveInfo MoveInfo { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.M2C_CreateMyUnit)]
	[ProtoContract]
	public partial class M2C_CreateMyUnit: Object, IActorMessage
	{
		[ProtoMember(1)]
		public UnitInfo Unit { get; set; }

	}

	[Message(OuterOpcode.M2C_StartSceneChange)]
	[ProtoContract]
	public partial class M2C_StartSceneChange: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long SceneInstanceId { get; set; }

		[ProtoMember(2)]
		public string SceneName { get; set; }

	}

	[Message(OuterOpcode.M2C_StartSceneChangeL)]
	[ProtoContract]
	public partial class M2C_StartSceneChangeL: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long SceneInstanceId { get; set; }

		[ProtoMember(2)]
		public string SceneName { get; set; }

	}

	[Message(OuterOpcode.M2C_RemoveUnits)]
	[ProtoContract]
	public partial class M2C_RemoveUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<long> Units = new List<long>();

	}

	[Message(OuterOpcode.C2M_PathfindingResult)]
	[ProtoContract]
	public partial class C2M_PathfindingResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.C2M_Stop)]
	[ProtoContract]
	public partial class C2M_Stop: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

		[ProtoMember(5)]
		public List<float> Xs = new List<float>();

		[ProtoMember(6)]
		public List<float> Ys = new List<float>();

		[ProtoMember(7)]
		public List<float> Zs = new List<float>();

	}

	[Message(OuterOpcode.M2C_Stop)]
	[ProtoContract]
	public partial class M2C_Stop: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public float X { get; set; }

		[ProtoMember(4)]
		public float Y { get; set; }

		[ProtoMember(5)]
		public float Z { get; set; }

		[ProtoMember(6)]
		public float A { get; set; }

		[ProtoMember(7)]
		public float B { get; set; }

		[ProtoMember(8)]
		public float C { get; set; }

		[ProtoMember(9)]
		public float W { get; set; }

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: Object, IMessage
	{
	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterOpcode.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Address { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public long GateId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long GateId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: Object, IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterOpcode.C2M_TestRobotCase)]
	[ProtoContract]
	public partial class C2M_TestRobotCase: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_TestRobotCase)]
	[ProtoContract]
	public partial class M2C_TestRobotCase: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterOpcode.C2M_TransferMap)]
	[ProtoContract]
	public partial class C2M_TransferMap: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TransferMap)]
	[ProtoContract]
	public partial class M2C_TransferMap: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(A2C_LoginAccount))]
	[Message(OuterOpcode.C2A_LoginAccount)]
	[ProtoContract]
	public partial class C2A_LoginAccount: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string AccountName { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.A2C_LoginAccount)]
	[ProtoContract]
	public partial class A2C_LoginAccount: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.G2C_Disconnect)]
	[ProtoContract]
	public partial class G2C_Disconnect: Object, IMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

	}

	[ResponseType(nameof(A2C_GetRealmKey))]
	[Message(OuterOpcode.C2A_GetRealmKey)]
	[ProtoContract]
	public partial class C2A_GetRealmKey: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetRealmKey)]
	[ProtoContract]
	public partial class A2C_GetRealmKey: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string RealmKey { get; set; }

		[ProtoMember(2)]
		public string RealmAddress { get; set; }

	}

	[ResponseType(nameof(R2C_LoginRealm))]
	[Message(OuterOpcode.C2R_LoginRealm)]
	[ProtoContract]
	public partial class C2R_LoginRealm: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

		[ProtoMember(2)]
		public string RealmKey { get; set; }

	}

	[Message(OuterOpcode.R2C_LoginRealm)]
	[ProtoContract]
	public partial class R2C_LoginRealm: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string GateAddress { get; set; }

		[ProtoMember(2)]
		public string GateSessionKey { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGameGate))]
	[Message(OuterOpcode.C2G_LoginGameGate)]
	[ProtoContract]
	public partial class C2G_LoginGameGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string GateKey { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public long RoleId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGameGate)]
	[ProtoContract]
	public partial class G2C_LoginGameGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[ResponseType(nameof(G2C_EnterGame))]
	[Message(OuterOpcode.C2G_EnterGame)]
	[ProtoContract]
	public partial class C2G_EnterGame: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public RoleInfoProto roleInfoProto { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterGame)]
	[ProtoContract]
	public partial class G2C_EnterGame: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long MyId { get; set; }

	}

	[ResponseType(nameof(G2C_ExitGame))]
	[Message(OuterOpcode.C2G_ExitGame)]
	[ProtoContract]
	public partial class C2G_ExitGame: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.G2C_ExitGame)]
	[ProtoContract]
	public partial class G2C_ExitGame: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.RoleInfoProto)]
	[ProtoContract]
	public partial class RoleInfoProto: Object
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

		[ProtoMember(4)]
		public string HeadSpriteName { get; set; }

		[ProtoMember(5)]
		public string PhotoSpriteName { get; set; }

		[ProtoMember(6)]
		public int goldCount { get; set; }

		[ProtoMember(7)]
		public int diamond { get; set; }

		[ProtoMember(8)]
		public long LastLoginTime { get; set; }

		[ProtoMember(9)]
		public long CreateTime { get; set; }

	}

	[ResponseType(nameof(A2C_CreateRole))]
	[Message(OuterOpcode.C2A_CreateRole)]
	[ProtoContract]
	public partial class C2A_CreateRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public string Name { get; set; }

		[ProtoMember(4)]
		public int ServerId { get; set; }

		[ProtoMember(5)]
		public string headName { get; set; }

		[ProtoMember(6)]
		public string charName { get; set; }

	}

	[Message(OuterOpcode.A2C_CreateRole)]
	[ProtoContract]
	public partial class A2C_CreateRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public RoleInfoProto RoleInfo { get; set; }

	}

	[ResponseType(nameof(A2C_GetRole))]
	[Message(OuterOpcode.C2A_GetRole)]
	[ProtoContract]
	public partial class C2A_GetRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetRole)]
	[ProtoContract]
	public partial class A2C_GetRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public RoleInfoProto RoleInfo { get; set; }

	}

	[ResponseType(nameof(M2C_Test))]
	[Message(OuterOpcode.C2M_Test)]
	[ProtoContract]
	public partial class C2M_Test: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_Test)]
	[ProtoContract]
	public partial class M2C_Test: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.UnitLInfo)]
	[ProtoContract]
	public partial class UnitLInfo: Object
	{
		[ProtoMember(1)]
		public long UnitLId { get; set; }

		[ProtoMember(2)]
		public RoleInfoProto RoleInfoProto { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnitL)]
	[ProtoContract]
	public partial class M2C_CreateUnitL: Object, IActorMessage
	{
		[ProtoMember(1)]
		public UnitLInfo UnitLInfo { get; set; }

	}

	[ResponseType(nameof(M2C_StartMatching))]
	[Message(OuterOpcode.C2M_StartMatching)]
	[ProtoContract]
	public partial class C2M_StartMatching: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_StartMatching)]
	[ProtoContract]
	public partial class M2C_StartMatching: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.M2C_NewUnitLComeIn)]
	[ProtoContract]
	public partial class M2C_NewUnitLComeIn: Object, IActorMessage
	{
		[ProtoMember(1)]
		public UnitLInfo unitLInfo { get; set; }

	}

	[Message(OuterOpcode.RoomInfo)]
	[ProtoContract]
	public partial class RoomInfo: Object
	{
		[ProtoMember(1)]
		public long RoomId { get; set; }

		[ProtoMember(2)]
		public int RoomState { get; set; }

		[ProtoMember(3)]
		public int BasicScore { get; set; }

		[ProtoMember(4)]
		public int mutiple { get; set; }

	}

	[Message(OuterOpcode.M2C_RoomUnitLInfo)]
	[ProtoContract]
	public partial class M2C_RoomUnitLInfo: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<UnitLInfo> infoList = new List<UnitLInfo>();

		[ProtoMember(2)]
		public RoomInfo roomInfo { get; set; }

	}

	[Message(OuterOpcode.C2M_UnitLComeOut)]
	[ProtoContract]
	public partial class C2M_UnitLComeOut: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long RoomId { get; set; }

	}

	[Message(OuterOpcode.M2C_UnitLComeOut)]
	[ProtoContract]
	public partial class M2C_UnitLComeOut: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long UnitLId { get; set; }

		[ProtoMember(2)]
		public bool isRes { get; set; }

	}

	[Message(OuterOpcode.PokerProto)]
	[ProtoContract]
	public partial class PokerProto: Object
	{
		[ProtoMember(1)]
		public long PokerId { get; set; }

		[ProtoMember(2)]
		public string pokerName { get; set; }

		[ProtoMember(3)]
		public int PokerType { get; set; }

		[ProtoMember(4)]
		public int PokerValue { get; set; }

	}

	[Message(OuterOpcode.M2C_EnterMatchingState)]
	[ProtoContract]
	public partial class M2C_EnterMatchingState: Object, IActorMessage
	{
	}

	[Message(OuterOpcode.M2C_EnterGamingState)]
	[ProtoContract]
	public partial class M2C_EnterGamingState: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<PokerProto> PokerProtoList = new List<PokerProto>();

		[ProtoMember(2)]
		public List<PokerProto> keepPokerProtoList = new List<PokerProto>();

	}

	[Message(OuterOpcode.C2M_CallLordResult)]
	[ProtoContract]
	public partial class C2M_CallLordResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public bool isCall { get; set; }

	}

	[Message(OuterOpcode.M2C_SetLordCallState)]
	[ProtoContract]
	public partial class M2C_SetLordCallState: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long lordId { get; set; }

		[ProtoMember(2)]
		public long LastId { get; set; }

	}

	[Message(OuterOpcode.M2C_SetLordRobState)]
	[ProtoContract]
	public partial class M2C_SetLordRobState: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long robId { get; set; }

		[ProtoMember(2)]
		public long LastId { get; set; }

		[ProtoMember(3)]
		public bool isFirst { get; set; }

		[ProtoMember(4)]
		public bool isRob { get; set; }

		[ProtoMember(5)]
		public int Mutiple { get; set; }

	}

	[Message(OuterOpcode.C2M_RobLordResult)]
	[ProtoContract]
	public partial class C2M_RobLordResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public bool isRob { get; set; }

	}

	[Message(OuterOpcode.M2C_SetAddState)]
	[ProtoContract]
	public partial class M2C_SetAddState: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Mutiple { get; set; }

		[ProtoMember(2)]
		public long AddId { get; set; }

		[ProtoMember(3)]
		public long LastId { get; set; }

	}

	[Message(OuterOpcode.C2M_AddLordResult)]
	[ProtoContract]
	public partial class C2M_AddLordResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public bool isAdd { get; set; }

	}

	[Message(OuterOpcode.M2C_SetAddLordState)]
	[ProtoContract]
	public partial class M2C_SetAddLordState: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Mutiple { get; set; }

		[ProtoMember(2)]
		public long AddId { get; set; }

		[ProtoMember(3)]
		public long LastId { get; set; }

		[ProtoMember(4)]
		public bool isAdd { get; set; }

	}

	[Message(OuterOpcode.M2C_EnterFirstRound)]
	[ProtoContract]
	public partial class M2C_EnterFirstRound: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long OutId { get; set; }

		[ProtoMember(2)]
		public bool trueFirst { get; set; }

		[ProtoMember(3)]
		public int Mutiple { get; set; }

		[ProtoMember(4)]
		public long LastId { get; set; }

	}

	[Message(OuterOpcode.C2M_FightInfo)]
	[ProtoContract]
	public partial class C2M_FightInfo: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<PokerProto> pokerList = new List<PokerProto>();

		[ProtoMember(2)]
		public int PokerListType { get; set; }

		[ProtoMember(3)]
		public bool isOut { get; set; }

	}

	[Message(OuterOpcode.M2C_FightInfo)]
	[ProtoContract]
	public partial class M2C_FightInfo: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<PokerProto> pokerList = new List<PokerProto>();

		[ProtoMember(2)]
		public int PokerListType { get; set; }

		[ProtoMember(3)]
		public int mutiple { get; set; }

		[ProtoMember(4)]
		public long LastId { get; set; }

		[ProtoMember(5)]
		public int LastCount { get; set; }

		[ProtoMember(6)]
		public long nextId { get; set; }

		[ProtoMember(7)]
		public bool isOut { get; set; }

	}

	[Message(OuterOpcode.ResultInfo)]
	[ProtoContract]
	public partial class ResultInfo: Object
	{
		[ProtoMember(1)]
		public long UnitLId { get; set; }

		[ProtoMember(2)]
		public string name { get; set; }

		[ProtoMember(3)]
		public int deltaGold { get; set; }

	}

	[Message(OuterOpcode.M2C_ResultInfo)]
	[ProtoContract]
	public partial class M2C_ResultInfo: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long winId { get; set; }

		[ProtoMember(2)]
		public List<ResultInfo> resultList = new List<ResultInfo>();

	}

	[Message(OuterOpcode.M2C_UnexpectedDisconnect)]
	[ProtoContract]
	public partial class M2C_UnexpectedDisconnect: Object, IActorMessage
	{
		[ProtoMember(1)]
		public string name { get; set; }

	}

}
