using System.Collections.Generic;

namespace ET
{
    public class AudiosComponent:Entity,IAwake,IDestroy
    {
        public Dictionary<AudioType, Audio> audioDic;
    }
}