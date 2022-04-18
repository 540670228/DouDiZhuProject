namespace ET
{
    public static class SceneChangeHelper
    {
        // 场景切换协程
        public static async ETTask SceneChangeTo(Scene zoneScene, string sceneName, long sceneInstanceId)
        {
            zoneScene.RemoveComponent<AIComponent>();
            
            CurrentScenesComponent currentScenesComponent = zoneScene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = SceneFactory.CreateCurrentScene(sceneInstanceId, zoneScene.Zone, sceneName, currentScenesComponent);
            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();
         
            // 可以订阅这个事件中创建Loading界面
            Game.EventSystem.Publish(new EventType.SceneChangeStart() {ZoneScene = zoneScene});

            // 等待CreateMyUnit的消息
            WaitType.Wait_CreateMyUnit waitCreateMyUnit = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_CreateMyUnit>();
            M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            unitComponent.Add(unit);
            
            zoneScene.RemoveComponent<AIComponent>();
            
            Game.EventSystem.Publish(new EventType.SceneChangeFinish() {ZoneScene = zoneScene, CurrentScene = currentScene});

            // 通知等待场景切换的协程
            zoneScene.GetComponent<ObjectWait>().Notify(new WaitType.Wait_SceneChangeFinish());
        }

        public static async ETTask SceneChangeToL(Scene zoneScene, string sceneName, long sceneInstanceId)
        {

            CurrentScenesComponent currentScenesComponent = zoneScene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = SceneFactory.CreateCurrentScene(sceneInstanceId, zoneScene.Zone, sceneName, currentScenesComponent);
            UnitLComponent unitLComponent = currentScene.AddComponent<UnitLComponent>();

            // 等待CreateMyUnit的消息
            WaitType.Wait_CreateUnitL waitCreateUnitL = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_CreateUnitL>();
            Log.Debug("获取到UnitL,在客户端创建UnitL");
            M2C_CreateUnitL m2CCreateUnitL = waitCreateUnitL.Message;
            UnitL unitL = UnitLFactory.Create(currentScene, m2CCreateUnitL.UnitLInfo);
            //将unitL加入到unitComponent中
            unitLComponent.Add(unitL);

            await ETTask.CompletedTask;
        }
    }
}