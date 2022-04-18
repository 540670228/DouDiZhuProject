using System;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib;
using UnityEditor.UI;

namespace ET
{
    public static class PokerRoomHelper
    {
        public static PokerRoom CreatePokerRoom(Scene zoneScene , RoomInfo info)
        {
            PokerRoomComponent component = zoneScene.GetComponent<PokerRoomComponent>();
            PokerRoom room = component.AddChild<PokerRoom>();
            room.state = info.RoomState;
            room.mutiple = info.mutiple;
            room.basicScore = info.BasicScore;
            component.pokerRoom = room;
            room.RefreshRoomInfo();
            
            return room;
        }
        

        public static List<Poker> GetPokerList(PokerRoom room,List<PokerProto> protoList)
        {
            Log.Warning("客户端收到poker数量为 + "+protoList.Count);
            List<Poker> pokerList = new List<Poker>();
            foreach (var item in protoList)
            {
                //当前房间下重复利用
                Poker poker = room.GetChild<Poker>(item.PokerId);
                if (poker == null)
                {
                    poker = room.AddChildWithId<Poker>(item.PokerId);
                    poker.FromMessage(item);
                }
                pokerList.Add(poker);
            }

            return pokerList;
        }

        public static List<PokerProto> ToProtoList(this List<Poker> pokers)
        {
            List<PokerProto> protoList = new List<PokerProto>();
            foreach (Poker poker in pokers)
            {
                protoList.Add(poker.ToMessage());
            }

            return protoList;
        }

        public static void SortPokerViewList(this List<PokerView> pokerViewList)
        {
            Log.Warning("排序数组长度"+pokerViewList.Count);
            //冒泡排序
            for(int i = 0; i < pokerViewList.Count;i++)
                for (int j = 0; j < pokerViewList.Count - i - 1; j++)
                {
                    if (CompareView(pokerViewList[j], pokerViewList[j+1]))
                    {
                        PokerView tmp = pokerViewList[j];
                        pokerViewList[j] = pokerViewList[j + 1];
                        pokerViewList[j + 1] = tmp;
                    }
                }

        }

        public static void SetGameObjectIndex(this List<PokerView> pokerViewList)
        {
            //排序后对gameObject进行排序
            for (int i = 0; i < pokerViewList.Count; i++)
            {
                Log.Warning(pokerViewList[i].poker.pokerName + "索引" + i);
                pokerViewList[i].GetGameObject().transform.SetSiblingIndex(i);
            }
        }

        private static bool CompareView(PokerView a, PokerView b)
        {
            int value1 = (int) a.poker.pokerValue * 10 + (int)a.poker.pokerType;
            int value2 = (int) b.poker.pokerValue * 10 + (int) b.poker.pokerType;
            return value1 > value2;
        }
        
        public static string GetSuffix(Scene scene,long unitLId)
        {
            Sex sex = 
                    scene.GetComponent<CurrentScenesComponent>().Scene.GetComponent<UnitLComponent>().GetChild<UnitL>(unitLId).roleInfo.getSex();
            string suffix = sex == Sex.boy? "_boy" : "_girl";
            return suffix;
        }
        
        
        
        
    }
}