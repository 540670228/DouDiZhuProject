using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ET
{
    public class AudioAwakeSystem: AwakeSystem<Audio,AudioType>
    {
        /// <summary>
        /// Audio对象初始化
        /// </summary>
        /// <param name="self"></param>
        public override void Awake(Audio self,AudioType type)
        {
            self.audioType = type;
            self.clipsCache = new Dictionary<string, AudioClip>();
            //添加组件
            GameObjectComponent objComponent = self.AddComponent<GameObjectComponent>();
            AudioSourceComponent audioComponent =  self.AddComponent<AudioSourceComponent>();
            //创建对象 在根节点下
            Transform root = GlobalComponent.Instance.AudioRoot;
            GameObject go = new GameObject(type.ToString());
            go.transform.SetParent(root);
            objComponent.GameObject = go;
            //为对象添加AudioSource组件
            audioComponent.audioSource = go.AddComponent<AudioSource>();
        }
    }

    public class AudioDestroySystem: DestroySystem<Audio>
    {
        public override void Destroy(Audio self)
        {
            //销毁游戏对象
            GameObject.Destroy(self?.GetComponent<GameObjectComponent>()?.GameObject);
        }
    }

    public static class AudioSystem
    {
        public static void PlayMusic(this Audio self,string clipName)
        {
            if (!self.isOpen) return;
            Log.Debug("开始播放音乐");
            AudioClip clip;
            if (!self.clipsCache.ContainsKey(clipName))
            {
                clip = ResourceConfig.GetClip(clipName);
            }
            else clip = self.clipsCache[clipName];

            if (clip == null)
            {
                Log.Error("音乐加载失败 请检查资源名称");
                return;
            }

            switch (self.audioType)
            {
                case AudioType.Effect_Audio:
                    break;
                case AudioType.Operate_Audio:
                    break;
                case AudioType.BackGround_Audio:
                    //背景音乐循环播放
                    self.GetAudio().loop = true;
                    break;
                case AudioType.UI_Audio:
                    break;
            }
            
            //将上次的音乐暂停
            self.GetAudio().Stop();
            self.GetAudio().clip = clip;
            self.GetAudio().Play();
            Log.Debug("播放音乐完成");

        }

        public static AudioSource GetAudio(this Audio self)
        {
            return self.GetComponent<AudioSourceComponent>().audioSource;
        }

        //设置当前类型播放器的音量
        public static void SetVolumeValue(this Audio self, float value)
        {
            //设置百分比音量
            self.GetAudio().volume = value;
        }
        
        //设置禁用启用
        public static void SetVolumeState(this Audio self, bool state)
        {
            self.isOpen = state;
            if (self.audioType == AudioType.BackGround_Audio)
            {
                if(!state)
                    self.GetAudio().Pause();
                else self.GetAudio().Play();
                
            }
            
        }
    }
}