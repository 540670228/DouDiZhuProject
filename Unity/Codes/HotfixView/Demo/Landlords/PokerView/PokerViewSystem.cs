using System.Runtime.CompilerServices;
using ns;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class PokerViewAwakeSystem : AwakeSystem<PokerView>
    {
        public override void Awake(PokerView self)
        {
            //添加GameObject组件
            self.AddComponent<GameObjectComponent>();
            GameObject obj = ResourceConfig.GetPrefab(ConstValue.pokerPrefabName);
            obj = GameObject.Instantiate(obj);
            RectTransform rect = obj.transform as RectTransform;
            self.GetComponent<GameObjectComponent>().GameObject = obj;
            self.state = PokerViewState.Normal;
        }
    }
    
    public class PokerViewDestroySystem : DestroySystem<PokerView>
    {
        public override void Destroy(PokerView self)
        {
            if (self?.GetComponent<GameObjectComponent>()?.GameObject == null) return;
            //释放对象
            GameObject.Destroy(self?.GetComponent<GameObjectComponent>()?.GameObject);
        }
    }

    public static class PokerViewSystem
    {
        public static void CollectPokerView(this PokerView self)
        {
            self.GetComponent<GameObjectComponent>().GameObject?.SetActive(false);
        }
        
        public static void SetPokerView(this PokerView self, Poker poker,Transform parent,Vector3 localPos)
        {
            self.poker = poker;
            GameObject obj = self.GetComponent<GameObjectComponent>().GameObject;
            obj.SetActive(true);
            obj.transform.SetParent(parent);
            RectTransform rect = obj.transform as RectTransform;
            rect.anchoredPosition3D = localPos;
            obj.GetComponent<Image>().sprite = ResourceConfig.GetSprite(poker.pokerName);
        }

        public static GameObject GetGameObject(this PokerView self)
        {
            return self.GetComponent<GameObjectComponent>().GameObject;
        }

        public static void SetPokerViewState(this PokerView self, PokerViewState state)
        {
            switch (state)
            {
                case PokerViewState.Normal:
                    if (self.state == PokerViewState.Normal) return;
                    else self.state = PokerViewState.Normal;
                    //将牌移动回原位置
                    Vector3 offset = new Vector3(0, -ConstValue.offsetY, 0);
                    UITween.MoveToLocalPos(self.GetGameObject().transform as RectTransform, 
                        offset, ConstValue.UIMoveSpeed).Coroutine();
                    break;
                case PokerViewState.Prepare:
                    if (self.state == PokerViewState.Prepare) return;
                    else self.state = PokerViewState.Prepare;
                    //将牌向上移动
                    Vector3 offset1 = new Vector3(0, ConstValue.offsetY, 0);
                    UITween.MoveToLocalPos(self.GetGameObject().transform as RectTransform, 
                        offset1, ConstValue.UIMoveSpeed).Coroutine();

                    break;
            }
        }

        public static bool isActive(this PokerView self)
        {
            return self.GetComponent<GameObjectComponent>().GameObject.activeSelf;
        }

        public static void SetLocalPos(this PokerView self, Vector2 pos)
        {
            RectTransform rect = self.GetComponent<GameObjectComponent>().GameObject.transform as RectTransform;
            rect.anchoredPosition = pos;
        }

        public static PokerListener GetPokerListener(this PokerView self)
        {
            return self.GetGameObject().GetComponent<PokerListener>();
        }
    }
    
}