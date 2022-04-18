﻿namespace ET
{
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            await args.CurrentScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Helper);
        }
    }
}
