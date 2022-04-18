using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public enum AudioType
    {
        //背景音乐
        BackGround_Audio,
        //特殊效果
        Effect_Audio,
        //UI操作音效
        UI_Audio,
        //操作提示音
        Operate_Audio,
    }
    public class Audio:Entity,IAwake<AudioType>,IDestroy
    {
        public AudioType audioType;
        public bool isOpen = true;
        public Dictionary<string, AudioClip> clipsCache;
    }
}