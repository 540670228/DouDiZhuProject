using System.Collections.Generic;

namespace ET
{
    public class UIEventComponent : Entity,IAwake,IDestroy
    {
        public bool IsClicked { get; set; }
        public static UIEventComponent Instance { get; set; }
        public readonly Dictionary<WindowID, IAUIEventHandler> UIEventHandlers = new Dictionary<WindowID, IAUIEventHandler>();
    }
}