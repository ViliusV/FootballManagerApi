using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
	public class FakePlayerRepository : IPlayerRepository
	{
		private ICollection<Player> _players;

		public FakePlayerRepository()
		{
			FillData();
		}

		public Player Add(Player player)
		{
			player.Id = _players.Max(p => p.Id) + 1;
			_players.Add(player);

			return player;
		}

		public Player Get(int id)
		{
			return _players.SingleOrDefault(p => p.Id == id);
		}

		public bool Remove(int id)
		{
			var player = Get(id);
			if (player == null)
			{
				return false;
			}

			return _players.Remove(player);
		}

		public Player Update(Player player)
		{
			var existingPlayer = Get(player.Id);
			if (existingPlayer == null) 
			{
				return null;
			}

			existingPlayer.FirstName = player.FirstName;
			existingPlayer.LastName = player.LastName;
			existingPlayer.JerseyNumber = player.JerseyNumber;
			existingPlayer.TeamId = player.TeamId;

			return existingPlayer;
		}

		private void FillData()
		{
			_players = new List<Player>();

			// Manchester United Players
			Add(new Player("David", "De Gea", 1, 13));
			Add(new Player("Victor", "Lindelof", 2, 13));
			Add(new Player("Harry", "Maguire", 5, 13));
			Add(new Player("Paul", "Pogba", 6, 13));
			Add(new Player("Juan", "Mata", 8, 13));
			Add(new Player("Marcus", "Rashford", 10, 13));

			// Manchester City Players
			Add(new Player("Kyle", "Walker", 2, 12));
			Add(new Player("Raheem", "Sterling", 7, 12));
			Add(new Player("Kevin", "De Bruyne", 17, 12));
		}
	}
}
