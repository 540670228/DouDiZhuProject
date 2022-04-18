namespace ET
{
    public class PokerRoomAwakeSystem:AwakeSystem<PokerRoom>
    {
        public override void Awake(PokerRoom self)
        {
            
        }
    }
    
    public class PokerRoomDestroySystem : DestroySystem<PokerRoom>
    {
        public override void Destroy(PokerRoom self)
        {
            if (self == null) return;
            //销毁所有UnitL 除了自身
            foreach (UnitL item in self.unitList)
            {
                if (item.Id == self.ZoneScene()?.GetComponent<MyUnitLComponent>()?.unitL.Id)
                    continue;
                item?.Dispose();
            }
        }
    }

    public static class PokerRoomSystem
    {
        public static DlgRoom GetDlgRoom(this PokerRoom self)
        {
            return self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgRoom>();
        }

        public static DlgOperate GetDlgOperate(this PokerRoom self)
        {
            return self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgOperate>();
        }

        public static int getUnitLIndex(this PokerRoom self,long unitId)
        {
            for (int i = 0; i < self.unitList.Count; i++)
            {
                if (self.unitList[i].Id == unitId) return i;
            }

            return -1;
        }
        
        //是否空闲，是否还可以进入
        public static bool isRelax(this PokerRoom self)
        {
            return self.state == (int)RoomState.Matching;
        }
        
        //加入玩家
        public static void AddUnitL(this PokerRoom self, UnitL unitL,int index)
        {
            if (!isRelax(self))
            {
                Log.Error("此房间已经满员，无法进入");
                return;
            }
            self.unitList.Add(unitL);
            //TODO：将新玩家的形象加载到UI中
            self.GetDlgRoom().SetPlayer(unitL.roleInfo,index);
        }

        public static void RemoveUnitL(this PokerRoom self, int index)
        {
            self.unitList.RemoveAt(index);
            //TODO；移除玩家形象UI
            self.GetDlgRoom().RemovePlayer(index);
            
        }

        public static void EnterMatchingState(this PokerRoom self)
        {
            self.state = (int)RoomState.Matching;
            //TODO：通知UI进入到Matching界面
        }

        public static void RefreshRoomInfo(this PokerRoom self)
        {
            self.GetDlgRoom().SetMutiple(self.mutiple);
            self.GetDlgRoom().SetBasicScore(self.basicScore);
        }
    }
}