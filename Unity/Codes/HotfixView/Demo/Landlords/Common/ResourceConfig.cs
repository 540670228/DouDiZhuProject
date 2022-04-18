using System;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 缓存游戏资源
    /// </summary>
    public static class ResourceConfig
    {
        public static int headCount = 0;
        public static int photoCount = 0;
        private static Dictionary<string, Sprite> roleHeadDic = new Dictionary<string, Sprite>();
        private static Dictionary<string, Sprite> rolePhotoDic = new Dictionary<string, Sprite>();
        private static Dictionary<string, Sprite> spritesDic = new Dictionary<string, Sprite>();
        private static Dictionary<string, AudioClip> clipsDic = new Dictionary<string, AudioClip>();
        private static Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();

        static ResourceConfig()
        {
            //初始化头像信息
            InitRoleHead();
            
            //初始化形象信息
            InitRolePhoto();
        }

        private static void InitRoleHead()
        {
            //循环查找 直到为空
            int i = 0;
            while (true)
            {
                string name = ConstValue.roleHeadPrefix + i.ToString();
                Sprite head = ResourcesManager.Load<Sprite>(name);
                if (head == null)
                {
                    headCount = i;
                    return;
                }
                i++;
                
                roleHeadDic.Add(name,head);
            }
        }

        private static void InitRolePhoto()
        {
            //循环查找 直到为空
            int i = 0;
            while (true)
            {
                string name = ConstValue.rolePhotoPrefix + i.ToString();
                Sprite photo = ResourcesManager.Load<Sprite>(name);
                if (photo == null)
                {
                    photoCount = i;
                    return;
                }
                i++;
                rolePhotoDic.Add(name,photo);
            }
        }

        public static Sprite GetRoleHead(string name)
        {
            if (roleHeadDic.ContainsKey(name)) return roleHeadDic[name];
            else return null;
        }
        
        public static Sprite GetRolePhoto(string name)
        {
            if (rolePhotoDic.ContainsKey(name)) return rolePhotoDic[name];
            else return null;
        }

        public static Sprite GetSprite(string name)
        {
            if (!spritesDic.ContainsKey(name))
            {
                spritesDic.Add(name,ResourcesManager.Load<Sprite>(name)); 
            }

            return spritesDic[name];
        }

        public static AudioClip GetClip(string name)
        {
            if (!clipsDic.ContainsKey(name))
            {
                clipsDic.Add(name,ResourcesManager.Load<AudioClip>(name));
            }

            return clipsDic[name];
        }

        public static GameObject GetPrefab(string name)
        {
            if (!prefabDic.ContainsKey(name))
            {
                prefabDic.Add(name,ResourcesManager.Load<GameObject>(name));
            }

            return prefabDic[name];
        }
    }
}