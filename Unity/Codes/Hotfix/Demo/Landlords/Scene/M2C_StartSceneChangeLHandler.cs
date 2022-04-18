namespace ET
{
    [MessageHandler]
    public class M2C_StartSceneChangeLHandler : AMHandler<M2C_StartSceneChangeL>
    {
        protected override async ETTask Run(Session session, M2C_StartSceneChangeL message)
        {
            await SceneChangeHelper.SceneChangeToL(session.ZoneScene(), message.SceneName, message.SceneInstanceId);
        }
    }
}