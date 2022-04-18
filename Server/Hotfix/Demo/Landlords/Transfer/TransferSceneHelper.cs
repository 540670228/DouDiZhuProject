namespace ET
{
    public static class TransferSceneHelper
    {
        /// <summary>
        /// 负责将创建的UnitL传送到对应的服务器
        /// </summary>
        /// <param name="unit">unit实体</param>
        /// <param name="sceneInstanceId">目标Scene的ActorId</param>
        /// <param name="sceneName">目标Scene的Name 和 Excel配置的对应</param>
        public static async ETTask Transfer(UnitL unitL, long sceneInstanceId, string sceneName)
        {
            //1. 通知客户端切换场景   -- 切换zoneScene下CurrentSceneComponent的Scene
            M2C_StartSceneChangeL m2CStartSceneChange = new M2C_StartSceneChangeL() {SceneInstanceId = sceneInstanceId, SceneName = sceneName};
            MessageHelper.SendToClient(unitL , m2CStartSceneChange);

            M2M_UnitLTransferRequest request = new M2M_UnitLTransferRequest();
            request.UnitL = unitL;
            foreach (Entity entity in unitL.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity);
                }
            }
            // 删除Mailbox,让发给Unit的ActorLocation消息重发
            unitL.RemoveComponent<MailBoxComponent>();
            
            // location加锁
            long oldInstanceId = unitL.InstanceId;
            await LocationProxyComponent.Instance.Lock(unitL.Id, unitL.InstanceId);
            M2M_UnitLTransferResponse response = await ActorMessageSenderComponent.Instance.Call(sceneInstanceId, request) as M2M_UnitLTransferResponse;
            await LocationProxyComponent.Instance.UnLock(unitL.Id, oldInstanceId, response.NewInstanceId);
            unitL.Dispose();

        }
    }
}