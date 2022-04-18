using System;
using System.Collections.Generic;

namespace ET
{
    public class AudiosComponentAwakeSystem: AwakeSystem<AudiosComponent>
    {
        //初始化所有枚举的Audio对象
        public override void Awake(AudiosComponent self)
        {
            self.audioDic = new Dictionary<AudioType, Audio>();
            foreach (AudioType typeInfo in Enum.GetValues(typeof(AudioType)))
            {
                //创建audio 实体
                Audio audio = self.AddChild<Audio,AudioType>(typeInfo);
                //加入集合
                self.audioDic.Add(typeInfo,audio);
            }
        }
    }

    public static class AudiosComponentSystem
    {
        public static Audio GetAudio(this AudiosComponent self,AudioType type)
        {
            if (self.audioDic.ContainsKey(type))
                return self.audioDic[type];
            else return null;
        }
    }
}