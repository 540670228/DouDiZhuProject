namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();
            zoneScene.AddComponent<AudiosComponent>();
            zoneScene.AddComponent<PokerRoomComponent>();
            zoneScene.AddComponent<PokerViewsComponent>();

            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_LandlordsLogin);
            await ETTask.CompletedTask;
        }
    }
}