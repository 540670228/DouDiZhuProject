namespace ET
{
    public class UnitLGateComponentAwakeSystem : AwakeSystem<UnitLGateComponent, long>
    {
        public override void Awake(UnitLGateComponent self, long gateSessionId)
        {
            self.Awake(gateSessionId);
        }
    }
    public class UnitLGateComponent:Entity, IAwake<long>, ITransfer
    {
        public long GateSessionActorId;

        public void Awake(long gateSessionId)
        {
            this.GateSessionActorId = gateSessionId;
        }
    }
}