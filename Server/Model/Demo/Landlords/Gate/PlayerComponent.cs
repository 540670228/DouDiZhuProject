﻿using System.Collections.Generic;
using System.Linq;

namespace ET
{
	public class PlayerComponent : Entity, IAwake, IDestroy
	{
		//根据AccountId 获取Player
		private readonly Dictionary<long, Player> idPlayers = new Dictionary<long, Player>();
		
		public void Add(Player player)
		{
			this.idPlayers.Add(player.AccountId, player);
		}

		public Player Get(long id)
		{
			this.idPlayers.TryGetValue(id, out Player gamer);
			return gamer;
		}

		public void Remove(long id)
		{
			Log.Warning("移除角色！！");
			this.idPlayers.Remove(id);
		}

		public int Count
		{
			get
			{
				return this.idPlayers.Count;
			}
		}

		public Player[] GetAll()
		{
			return this.idPlayers.Values.ToArray();
		}
	}
}