using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Xml;
using ns;
using UnityEditor.UI;
using UnityEngine;

namespace ET
{
    public class PokerViewsComponentAwakeSystem: AwakeSystem<PokerViewsComponent>
    {
        public override void Awake(PokerViewsComponent self)
        {
        }
    }

    public static class PokerViewsComponentSystem
    {
        //提供回收所有实体牌的方法
        public static void CollectAll(this PokerViewsComponent self)
        {
            //销毁所有实体牌
            foreach (PokerView view in self.pokerViewList)
            {
                view.CollectPokerView();
            }
        }

        //生成获取一个实体牌
        public static PokerView GetPokerView(this PokerViewsComponent self, Poker poker, Transform parent, Vector3 localPos)
        {
            //寻找是否有空闲的view牌
            PokerView view = null;
            foreach (var item in self.pokerViewList)
            {
                if (!item.isActive())
                {
                    view = item;
                    break;
                }
            }
            if(view == null)
            {
                view = self.AddChild<PokerView>();
                self.pokerViewList.Add(view);
            }
            view.state = PokerViewState.Normal;
            view.SetPokerView(poker, parent, localPos);

            return view;
        }

        public static void SetPokerViewDepth(this PokerViewsComponent self, PokerView view,int index)
        {
            view.GetGameObject().transform.SetSiblingIndex(index);
        }

        //存放自身所有的牌
        public static void SetMyPokerView(this PokerViewsComponent self, List<Poker> pokerList)
        {
            for (int i = 0; i < pokerList.Count; i++)
            {
                //第一张牌 直接生成 第二张牌在第一张牌位置生成后移动 移动完后第三章牌接着生成移动重复
                if (i == 0)
                {
                    PokerView view = self.GetPokerView(pokerList[i], self.GetDlgOperate().GetSelfViewRoot(), Vector3.zero);
                    self.selfPokerViewList.Add(view);
                    self.SetPokerViewDepth(view,i);
                }
                else
                {
                    //全都生成到0，同时向右移动
                    PokerView view = self.GetPokerView(pokerList[i], self.GetDlgOperate().GetSelfViewRoot(),
                        Vector3.zero);
                    self.SetPokerViewDepth(view,i);
                    //向右偏移40*i
                    UITween.MoveToTargetPos(view.GetGameObject().transform as RectTransform,
                        new Vector3(ConstValue.offsetX * i, 0, 0), ConstValue.UIMoveSpeed).Coroutine();
                    //加入到自身列表中
                    self.selfPokerViewList.Add(view);
                }
            }

        }

        public static void InsertKeepPokerView(this PokerViewsComponent self, List<Poker> keepPokerList)
        {
            List<PokerView> tmpList = new List<PokerView>();
            //插入三张牌到我的手中
            for (int i = 0; i < keepPokerList.Count; i++)
            {
                PokerView view = self.GetPokerView(keepPokerList[i], self.GetDlgOperate().GetSelfViewRoot(),
                    Vector3.zero);
                
                //插入后重新排序重新直接生成  加入的牌缩放一下
                self.selfPokerViewList.Add(view);
                //暂存 后续位移
                tmpList.Add(view);
            }
            
            //对牌重新排序
            PokerRoomHelper.SortPokerViewList(self.selfPokerViewList);
            PokerRoomHelper.SetGameObjectIndex(self.selfPokerViewList);
            //排序完直接显示出来
            for (int i = 0; i < self.selfPokerViewList.Count; i++)
            {
                //直接显示到对应位置
                self.selfPokerViewList[i].SetLocalPos(new Vector3(ConstValue.offsetX*i,0,0));
            }
            
            //对三张牌进行位移
            foreach (var item in tmpList)
            {
                RectTransform rect = item.GetGameObject().transform as RectTransform;
                //从右上角飞入
                rect.MoveFromLocalPos(rect.anchoredPosition + Vector2.one * 40, ConstValue.flyUISpeed).Coroutine();
            }
        }
        
        public static void SetKeepPokerView(this PokerViewsComponent self, List<Poker> keepPokerList)
        {
            //设置底牌的图片
            self.GetDlgOperate().SetKeepPoker(keepPokerList);
            //对三张底牌进行缩放动画
            self.GetDlgOperate().View.EImage_KeepPoker0Image.transform.StartScaleTween(ConstValue.scaleMutiple, ConstValue.UIScaleSpeed).Coroutine();
            self.GetDlgOperate().View.EImage_KeepPoker1Image.transform.StartScaleTween(ConstValue.scaleMutiple, ConstValue.UIScaleSpeed).Coroutine();
            self.GetDlgOperate().View.EImage_KeepPoker2Image.transform.StartScaleTween(ConstValue.scaleMutiple, ConstValue.UIScaleSpeed).Coroutine();
        }

        public static void SetPokerViewInteraction(this PokerViewsComponent self,List<PokerView> pokerViewList = null)
        {
            if (pokerViewList == null)
                pokerViewList = self.selfPokerViewList;
            foreach (PokerView item in pokerViewList)
            {
                item.GetPokerListener().onPointerSlider += () =>
                {
                    //设置相应的状态
                    if (item.state == PokerViewState.Normal)
                    {
                        item.SetPokerViewState(PokerViewState.Prepare);
                        //加入列表
                        self.selectPokerViewList.Add(item);
                    }
                    else if (item.state == PokerViewState.Prepare)
                    {
                        item.SetPokerViewState(PokerViewState.Normal);
                        //移除列表
                        self.selectPokerViewList.Remove(item);
                    }
                    
                };
            }
        }
        

        public static void RemovePokerViewInteraction(this PokerViewsComponent self, List<PokerView> pokerViewList)
        {
            //牌打出去后 移除交互
            foreach (var item in pokerViewList)
            {
                item.GetPokerListener().RemoveAllListener();
            }
            
        }

        public static DlgOperate GetDlgOperate(this PokerViewsComponent self)
        {
            return self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgOperate>();
        }
        /// <summary>
        /// 做新一局游戏的准备工作
        /// </summary>
        /// <param name="self"></param>
        public static void PrepareGame(this PokerViewsComponent self)
        {
            //清空所有列表
            self.selfPokerViewList.Clear();
            self.player0OutPokerList.Clear();
            self.player1OutPokerList.Clear();
            self.player2OutPokerList.Clear();
            self.selectPokerViewList.Clear();

            //取消所有监听
            self.RemovePokerViewInteraction(self.pokerViewList);
            //回收所有gameObject
            self.CollectAll();
            //通知UI部分重新Init
            self.GetDlgOperate().InitWindow();
            

        }
        
        //提供PokerViewList到pokerList的转换
        public static List<Poker> ToPokerList(this PokerViewsComponent self, List<PokerView> viewList)
        {
            List<Poker> pokerList = new List<Poker>();
            foreach (PokerView view in viewList)
            {
                pokerList.Add(view.poker);
            }

            return pokerList;
        }
        
        
        //出牌逻辑
        public static void PokerGo(this PokerViewsComponent self)
        {
            //测试用
            string str = "";
            foreach (var item in self.selectPokerViewList) str += item.poker.pokerName + "  ";
            Log.Warning("出牌："+str);

            //1. 判断牌型是否正确
            List<Poker> pokers;
            pokers = self.ToPokerList(self.selectPokerViewList);
            PokerListType plType = PokerListTypeHelper.GetPokerListType(pokers);
            Log.Warning("牌型:"+plType.ToString());
            if (plType != PokerListType.None)
            {
                //进行排序
                PokerRoomHelper.SortPokerViewList(self.selectPokerViewList);
                
                //先清空原出牌区view
                foreach (PokerView pokerView in self.player0OutPokerList)
                {
                    pokerView.CollectPokerView();
                }
                self.player0OutPokerList.Clear();
                
                //计算剩余牌型的偏移量
                float[] offsetArr = new float[self.selfPokerViewList.Count];
                for (int i = 0; i < offsetArr.Length; i++)
                {
                    if (self.selectPokerViewList.Contains(self.selfPokerViewList[i]))
                    {
                        for (int j = 0; j < offsetArr.Length; j++)
                        {
                            if (j == i) offsetArr[j] = 0;
                            else if (j < i) offsetArr[j] += ConstValue.offsetX * 0.5f;
                            else offsetArr[j] -= ConstValue.offsetX * 0.5f;
                        }
                    }
                }
                
                //将新牌移动到出牌区
                Vector2 basic = self.GetDlgOperate().View.ERoot_Poker0Image.rectTransform.anchoredPosition;
                for(int i = 0; i < self.selectPokerViewList.Count; i++)
                {
                    Vector2 pos = basic + new Vector2(ConstValue.offsetX * i, 0);
                    Log.Warning("将" + self.selectPokerViewList[i].poker.pokerName + "放入Root下");
                    
                    //将gameObejct移动到出牌区子物体
                    self.selectPokerViewList[i].GetGameObject().transform.
                            SetParent(self.GetDlgOperate().View.ERoot_Poker0Image.transform);
                    /*RectTransform rect = self.selectPokerViewList[i].GetGameObject().transform as RectTransform;
                    rect.MoveToTargetPos(pos, ConstValue.UIMoveSpeed * 5).Coroutine();*/
                    self.selectPokerViewList[i].SetLocalPos(pos); //不加动画
                    self.player0OutPokerList.Add(self.selectPokerViewList[i]);
                    
                    
                }
                PokerRoomHelper.SortPokerViewList(self.selectPokerViewList);
                //将剩余的牌进行靠拢 从后往前 边靠拢 边删除
                for (int i = offsetArr.Length - 1; i >= 0; i--)
                {
                    if (self.selectPokerViewList.Contains(self.selfPokerViewList[i]))
                        self.selfPokerViewList.RemoveAt(i);
                    else
                    {
                        RectTransform rect = self.selfPokerViewList[i].GetGameObject().transform as RectTransform;
                        rect.MoveToLocalPos(new Vector3(offsetArr[i],0,0), ConstValue.UIMoveSpeed * 3).Coroutine();
                    }
                }

                //关闭交互
                self.RemovePokerViewInteraction(self.selectPokerViewList);
                //移除出选择列表
                self.selectPokerViewList.Clear();
                
                //向服务器发送消息
                self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_FightInfo()
                {
                    pokerList = pokers.ToProtoList(),
                    PokerListType = (int)plType,
                    isOut = true,
                });

            }
            else
            {
                //提示
                self.GetDlgOperate().View.ESTipsUI.
                        ShowTips(ErrorCodeHelper.GetErrorInfo(ErrorCode.ERR_PokerListTypeError));
            }
            
        }

        public static void PokerExamineGo(this PokerViewsComponent self,List<Poker> LastPokers,PokerListType LastType)
        {
            bool isPass = true;
            //1.基本类型一致个数一致  比较大小  特殊类型三带一 飞机 四带n 需要比较有效牌的最大值
            List<Poker> curPokers = self.ToPokerList(self.selectPokerViewList);
            PokerListType curType = PokerListTypeHelper.GetPokerListType(curPokers);
            if (curType == LastType && curPokers.Count == LastPokers.Count)
            {
                //比较值的大小
                int lastTotalValue = 0;
                int curTotalValue = 0;
                //特殊大小的判断
                if (curType == PokerListType.PlaneWithOne || curType == PokerListType.PlaneWithPair ||
                    curType == PokerListType.PlaneWithZero || curType == PokerListType.ThreeWithOne ||
                    curType == PokerListType.ThreeWithPair)
                {

                    //比较3张牌的最大的有效值
                    lastTotalValue = GetMaxUsefulValue(LastPokers,3);
                    curTotalValue = GetMaxUsefulValue(curPokers,3);
                }
                else if (curType == PokerListType.FourWithOne ||
                         curType == PokerListType.FourWithPair)
                {
                    //比较4张牌的最大的有效值
                    lastTotalValue = GetMaxUsefulValue(LastPokers,4);
                    curTotalValue = GetMaxUsefulValue(curPokers,4);
                }
                else
                {
                    for (int i = 0; i < curPokers.Count; i++)
                    {
                        lastTotalValue += (int) LastPokers[i].pokerValue;
                        curTotalValue += (int) curPokers[i].pokerValue;
                    }
                }

                if (lastTotalValue >= curTotalValue) isPass = false;
            }
            else
            {
                //2.类型不一致 判断炸弹
                if (curType != PokerListType.BigBoom && curType != PokerListType.NormalBoom)
                {
                    isPass = false;
                }
            }
            
            if (isPass)
            {
                Log.Warning("牌通过检验 发出！");
                self.PokerGo();
            }
            else
            {
                //提示玩家不规范
                self.GetDlgOperate().View.ESTipsUI.ShowTips(ErrorCodeHelper.GetErrorInfo(ErrorCode.ERR_PokerListTypeError));
                Log.Warning("牌不规范，无法发出");
            }
        }

        private static int GetMaxUsefulValue(List<Poker> LastPokers,int maxCount)
        {
            //飞机的最大有效值为 3个头 最大的
            //三带一最大有效值也为 3个头 最大的
            Dictionary<PokerValue, int> pokerCountDic = new Dictionary<PokerValue, int>();
            int res = 0;
            foreach (Poker poker in LastPokers)
            {
                if (pokerCountDic.ContainsKey(poker.pokerValue))
                    pokerCountDic[poker.pokerValue]++;
                else pokerCountDic.Add(poker.pokerValue,1);

                if (pokerCountDic[poker.pokerValue] == maxCount)
                {
                    res = Mathf.Max(res, (int) poker.pokerValue);
                }
            }

            return res;

        }
        
        //不出牌
        public static void OutNo(this PokerViewsComponent self,List<Poker> lastPokers,PokerListType lastType)
        {
            //取消选中状态
            self.CancelAllSelect();
            //发送不出牌消息  牌为上一家的牌
            self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_FightInfo()
            {
                isOut = false,
                pokerList = lastPokers.ToProtoList(),
                PokerListType = (int)lastType,
            });
        }

        public static void CancelAllSelect(this PokerViewsComponent self)
        {
            foreach (PokerView view in self.selectPokerViewList)
            {
                view.SetPokerViewState(PokerViewState.Normal);
            }
            self.selectPokerViewList.Clear();
        }

        public static void SetOutPoker(this PokerViewsComponent self, int index, List<Poker> pokerList)
        {
            //清空所有pokerView
            //先清空之前的pokerView
            for (int i = 0; i < 3; i++)
            {
                foreach (var view in self.GetOutPokerList(i))
                {
                    view.CollectPokerView();
                }
                self.GetOutPokerList(i).Clear();
            }
            
            
            //获取根节点
            Transform root = root = self.GetDlgOperate().GetViewRoot(index);

            for (int i = 0; i < pokerList.Count; i++)
            {
                PokerView view = self.GetPokerView(pokerList[i], root, new Vector3(ConstValue.offsetX * i, 0, 0));
                self.GetOutPokerList(index).Add(view);
            }
            
            //排序list 和 gameobject
            self.GetOutPokerList(index).SortPokerViewList();
            self.GetOutPokerList(index).SetGameObjectIndex();
        }

        public static List<PokerView> GetOutPokerList(this PokerViewsComponent self, int index)
        {
            switch (index)
            {
                case 0:
                    return self.player0OutPokerList;
                case 1:
                    return self.player1OutPokerList;
                case 2:
                    return self.player2OutPokerList;
            }

            return null;
        }


    }
}
