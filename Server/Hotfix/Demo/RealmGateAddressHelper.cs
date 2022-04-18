using System.Collections.Generic;


namespace ET
{
	public static class RealmGateAddressHelper
	{
		public static StartSceneConfig GetGate(int zone,long accountId = -1)
		{
			List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zone];

			int n;
			if(accountId == -1)
				n = RandomHelper.RandomNumber(0, zoneGates.Count);
			else 
				n = accountId.GetHashCode() % zoneGates.Count;

			return zoneGates[n];
		}
		
		public static StartSceneConfig GetRealm(int zone)
		{
			//根据区服获取相应的Realms网关信息
			StartSceneConfig zoneRealm = StartSceneConfigCategory.Instance.Realms[zone];

			return zoneRealm;
		}
	}
}
