using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class M2C_FightInfoHandler : AMHandler<M2C_FightInfo>
    {
        protected async override ETTask Run(Session session, M2C_FightInfo message)
        {
            //更新倍数，更新牌数
            PokerRoom room = session.ZoneScene().GetComponent<PokerRoomComponent>().pokerRoom;
            PokerViewsComponent component = session.ZoneScene().GetComponent<PokerViewsComponent>();
            room.mutiple = message.mutiple;
            room.RefreshRoomInfo();
            int lastIndex = room.getUnitLIndex(message.LastId);
            room.GetDlgOperate().SetBackCount(lastIndex,message.LastCount);
            List<Poker> pokerList = PokerRoomHelper.GetPokerList(room,message.pokerList);
            if (message.isOut == false)
            {
                //设置出牌提示信息
                room.GetDlgOperate().SetOneInfoImage(ConstValue.outNo,lastIndex);
            }
            else
            {
                //更新牌的显示
                component.SetOutPoker(lastIndex,pokerList);
            }
            //TODO:特效的播放  顺子 炸弹 飞机 打牌  牌的声效
            PlayMusic(session,(PokerListType)message.PokerListType,message);
            
            //设置按钮组等等
            int nextIndex = room.getUnitLIndex(message.nextId);
            room.GetDlgOperate().SetNormalRound(nextIndex,pokerList,(PokerListType)message.PokerListType);
            
            await ETTask.CompletedTask;
        }

        private void PlayMusic(Session session,PokerListType type,M2C_FightInfo message)
        {
            if (type == PokerListType.NormalBoom || type == PokerListType.BigBoom)
            {
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Effect_Audio).PlayMusic(ConstValue.Effect_Bomb_Music);
            }
            else if (type == PokerListType.PlaneWithOne || type == PokerListType.PlaneWithPair)
            {
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Effect_Audio).PlayMusic(ConstValue.Effet_Plane_Music);
            }
            else
            {
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Effect_Audio).PlayMusic(ConstValue.Effect_Normal_Music);
            }
            //============播放Operate  打的牌===================
            string suffix = PokerRoomHelper.GetSuffix(session.ZoneScene(), message.LastId);

            string str = message.pokerList[0].PokerValue +suffix;
            switch (message.pokerList[0].PokerValue)
            {
                case 14: 
                    str = "1" + suffix;
                    break;
                case 15:
                    str = "2" + suffix;
                    break;
                case 16:
                    str = "14" + suffix;
                    break;
                case 17:
                    str = "15" + suffix;
                    break;
            }
            switch (type)
            {
                case PokerListType.PlaneWithOne:
                case PokerListType.PlaneWithPair:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_feiji_Music + suffix);
                    break;
                case PokerListType.BigBoom:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_JokerBomb_Music+ suffix);
                    break;
                case PokerListType.NormalBoom:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_NormalBomb_Music+ suffix);
                    break;
                case PokerListType.ThreeWithOne:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_threeWithOne_Music+ suffix);
                    break;
                case PokerListType.ThreeWithPair:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_threeWithPair_Music+ suffix);
                    break;
                case PokerListType.StraightOne:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_shunzi_Music+ suffix);
                    break;
                case PokerListType.StraightPair:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_liandui_Music+ suffix);
                    break;
                case PokerListType.Single:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic(str);
                    break;
                case PokerListType.Pair:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic("dui" + str);
                    break;
                case PokerListType.PlaneWithZero:
                    session.ZoneScene().GetComponent<AudiosComponent>().
                            GetAudio(AudioType.Operate_Audio).PlayMusic("tuple" + str);
                    break;
            }
            
            if(message.LastCount == 1)
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_BaoJing1_Music + suffix);
            if(message.LastCount == 2)
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_BaoJing2_Music + suffix);
            
            //如果没出的音效
            if(!message.isOut)
                session.ZoneScene().GetComponent<AudiosComponent>().
                        GetAudio(AudioType.Operate_Audio).PlayMusic(ConstValue.Operate_buyao_Music + suffix);

        }
    }
}