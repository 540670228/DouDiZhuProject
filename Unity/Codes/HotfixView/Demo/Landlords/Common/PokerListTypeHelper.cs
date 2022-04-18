using System.Collections.Generic;

namespace ET
{
    public static class PokerListTypeHelper
    {
        public static void RemoveById(this List<Poker> pokers, long Id)
        {
            int index = pokers.FindIndex(p => p.Id == Id);
            if (index < 0) return;
            pokers.RemoveAt(index);
        }
        public static void SortPoker(List<Poker> pokerList,bool isAscend = true)
        {
            //冒泡排序
            for(int i = 0; i < pokerList.Count;i++)
                for (int j = 0; j < pokerList.Count - i - 1; j++)
                {
                    if (ComparePoker(pokerList[j], pokerList[j+1]))
                    { 
                        Poker tmp = pokerList[j];
                        pokerList[j] = pokerList[j + 1];
                        pokerList[j + 1] = tmp;
                    }
                }
        }

        private static bool ComparePoker(Poker p1, Poker p2)
        {
            int value1 = (int) p1.pokerValue * 10 + (int) p1.pokerType;
            int value2 = (int) p2.pokerValue * 10 + (int) p2.pokerType;
            return value1 > value2;
        }
        
        //判断是否为Single
        public static bool isSingle(List<Poker> pList)
        {
            return pList.Count == 1;
        }

        public static bool isPair(List<Poker> pList)
        {
            return pList.Count == 2 && pList[0].pokerValue == pList[1].pokerValue;
        }

        public static bool isThreeWithZero(List<Poker> pList)
        {
            return pList.Count == 3 &&
                    pList[0].pokerValue == pList[1].pokerValue &&
                    pList[0].pokerValue == pList[2].pokerValue;
        }

        public static bool isThreeWithOne(List<Poker> pList)
        {
            // 7779  3777
            if (pList.Count == 4)
            {
                bool state1 = pList[0].pokerValue != pList[1].pokerValue &&
                        pList[1].pokerValue == pList[2].pokerValue &&
                        pList[1].pokerValue == pList[3].pokerValue;
                bool state2 = pList[0].pokerValue == pList[1].pokerValue &&
                        pList[0].pokerValue == pList[2].pokerValue &&
                        pList[0].pokerValue != pList[3].pokerValue;
                return state1 || state2;
            }
            else return false;
        }

        public static bool isThreeWithPair(List<Poker> pList)
        {
            //33444  44455
            if (pList.Count == 5)
            {
                bool state1 = pList[0].pokerValue == pList[1].pokerValue &&
                        pList[0].pokerValue == pList[2].pokerValue &&
                        pList[3].pokerValue == pList[4].pokerValue;
                bool state2 = pList[0].pokerValue == pList[1].pokerValue &&
                        pList[2].pokerValue == pList[3].pokerValue &&
                        pList[2].pokerValue == pList[4].pokerValue;
                return state1 || state2;
            }
            else return false;
        }

        public static bool isFourWithOne(List<Poker> pList)
        {
            //345555  355556  555567   335555  555566
            if (pList.Count == 6)
            {
                //判断是否有四张牌相同即可
                bool state1 = pList[0].pokerValue == pList[1].pokerValue &&
                        pList[0].pokerValue == pList[2].pokerValue &&
                        pList[0].pokerValue == pList[3].pokerValue;
                bool state2 = pList[1].pokerValue == pList[2].pokerValue &&
                        pList[1].pokerValue == pList[3].pokerValue &&
                        pList[1].pokerValue == pList[4].pokerValue;
                bool state3 = pList[2].pokerValue == pList[3].pokerValue &&
                        pList[2].pokerValue == pList[4].pokerValue &&
                        pList[2].pokerValue == pList[5].pokerValue;
                return state1 || state2 || state3;
            }
            else return false;
        }

        public static bool isFourWithPair(List<Poker> pList)
        {
            //33445555  33555566  55556677
            if (pList.Count != 8) return false;
            //4张一样的牌 和两张一样的牌
            Dictionary<PokerValue, int> countDic = new Dictionary<PokerValue, int>();
            foreach (Poker poker in pList)
            {
                if (countDic.ContainsKey(poker.pokerValue))
                {
                    countDic[poker.pokerValue]++;
                }
                else countDic.Add(poker.pokerValue, 1);

            }

            int pairCount = 0, fourCount = 0;
            foreach (var item in countDic)
            {
                if (item.Value == 2) pairCount++;
                if (item.Value == 4) fourCount++;
            }

            return pairCount == 2 && fourCount == 1;
        }
        
        public static bool isBigBoom(List<Poker> pList)
        {
            return pList.Count == 2 && 
                    pList[0].pokerValue == PokerValue.SJoker && 
                    pList[1].pokerValue == PokerValue.LJoker;
        }

        public static bool isNormalBoom(List<Poker> pList)
        {
            if (pList.Count == 4)
            {
                return pList[0].pokerValue == pList[1].pokerValue &&
                        pList[0].pokerValue == pList[2].pokerValue &&
                        pList[0].pokerValue == pList[3].pokerValue;
            }
            else return false;
        }

        public static bool isStraightOne(List<Poker> pList)
        {
            if (pList.Count < 5 || pList.Count > 12)
            {
                return false;
            }

            for (int i = 0; i < pList.Count - 1; i++)
            {
                if (pList[i].pokerValue > PokerValue.One) return false;
                if (pList[i + 1].pokerValue - pList[i].pokerValue != 1)
                    return false;
                if (pList[i + 1].pokerValue > PokerValue.One || pList[i].pokerValue > PokerValue.One)
                    return false;
            }

            return true;

        }

        public static bool isStraightPair(List<Poker> pList)
        {
            if (pList.Count < 6 || pList.Count % 2 != 0)
            {
                return false;
            }

            for (int i = 0; i < pList.Count - 1; i += 2)
            {
                if (pList[i].pokerValue > PokerValue.One) return false;
                
                if (pList[i].pokerValue == pList[i + 1].pokerValue)
                {
                    if (i + 2 < pList.Count && pList[i + 2].pokerValue - pList[i].pokerValue != 1)
                        return false;
                }
                else return false;
            }

            return true;
        }

        public static bool isPlaneWithZero(List<Poker> pList)
        {
            //333 444 555 ...
            if (pList.Count < 6 || pList.Count % 3 != 0) return false;

            for (int i = 0; i < pList.Count - 2; i += 3)
            {
                if (pList[i].pokerValue > PokerValue.One) return false;
                if (pList[i].pokerValue == pList[i + 1].pokerValue &&
                    pList[i].pokerValue == pList[i + 2].pokerValue)
                {
                    if (i + 3 < pList.Count && pList[i + 3].pokerValue - pList[i].pokerValue != 1)
                        return false;
                }
                else return false;
            }

            return true;
        }

        public static bool isPlaneWithOne(List<Poker> pList)
        {
            // 3335 3444 5556
            if (pList.Count < 8 || pList.Count % 4 != 0) return false;
            //记录牌数
            Dictionary<PokerValue, int> pokerCountDic = new Dictionary<PokerValue, int>();
            List<Poker> planeList = new List<Poker>();
            foreach (Poker poker in pList)
            {
                if (pokerCountDic.ContainsKey(poker.pokerValue))
                    pokerCountDic[poker.pokerValue]++;
                else pokerCountDic.Add(poker.pokerValue,1);
                if(pokerCountDic[poker.pokerValue]==3)
                    planeList.Add(poker);
            }
            //4张牌一个飞机  8张牌 2个飞机
            if (planeList.Count != pList.Count / 4) return false;
            return true;
        }

        public static bool isPlaneWithPair(List<Poker> pList)
        {
            // 44433 55566
            if (pList.Count < 10 || pList.Count % 5 != 0) return false;
            //记录牌数
            Dictionary<PokerValue, int> pokerCountDic = new Dictionary<PokerValue, int>();
            List<Poker> planeList = new List<Poker>();
            foreach (Poker poker in pList)
            {
                if (pokerCountDic.ContainsKey(poker.pokerValue))
                    pokerCountDic[poker.pokerValue]++;
                else pokerCountDic.Add(poker.pokerValue,1);
                if(pokerCountDic[poker.pokerValue]==3)
                    planeList.Add(poker);
            }
            //5张牌一个飞机  10张牌 2个飞机
            if (planeList.Count != pList.Count / 5) return false;
            return true;

        }

        /// <summary>
        /// 获取一组牌的类型
        /// </summary>
        /// <param name="pList">一组牌</param>
        /// <returns>牌组类型</returns>
        public static PokerListType GetPokerListType(List<Poker> pList)
        {
            //先进行排序
            SortPoker(pList);
            
            if (pList == null || pList.Count == 0) return PokerListType.None;
            switch (pList.Count)
            {
                case 1:
                    if (isSingle(pList))
                        return PokerListType.Single;
                    
                    break;
                case 2:
                    if (isPair(pList))
                        return PokerListType.Pair;
                    if (isBigBoom(pList))
                        return PokerListType.BigBoom;
                    break;
                case 3:
                    if (isThreeWithZero(pList))
                        return PokerListType.ThreeWithZero;
                    break;
                case 4:
                    if (isNormalBoom(pList))
                        return PokerListType.NormalBoom;
                    if (isThreeWithOne(pList))
                        return PokerListType.ThreeWithOne;
                    break;
                case 5:
                    if (isThreeWithPair(pList))
                        return PokerListType.ThreeWithPair;
                    if (isStraightOne(pList))
                        return PokerListType.StraightOne;
                    break;
                default:
                    //6张牌 以及以上判断 单顺 双顺 飞机 四带2个单 四带两个对
                    if (isStraightOne(pList)) return PokerListType.StraightOne;
                    if (isStraightPair(pList)) return PokerListType.StraightPair;
                    if (isPlaneWithZero(pList)) return PokerListType.PlaneWithZero;
                    if (isPlaneWithOne(pList)) return PokerListType.PlaneWithOne;
                    if (isPlaneWithPair(pList)) return PokerListType.PlaneWithPair;
                    if (isFourWithOne(pList)) return PokerListType.FourWithOne;
                    if (isFourWithPair(pList)) return PokerListType.FourWithPair;
                    return PokerListType.None;
            }
            return PokerListType.None;
        }

        private static PokerValue getMaxCountPoker(List<Poker> pList)
        {
            //摩尔投票法 超过一半的数
            int count = 0;
            PokerValue cur = pList[0].pokerValue;
            foreach (var item in pList)
            {
                if (count == 0)
                {
                    cur = item.pokerValue;
                }
                if (item.pokerValue == cur) count++;
                else count--;
            }

            return cur;
        }
        
        
        
    }
}