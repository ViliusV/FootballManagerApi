using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
	public class FakeGameRepository : IGameRepository
	{
		private ICollection<Game> _games;

		public FakeGameRepository()
		{
			FillData();
		}

		public Game Add(Game game)
		{
			var newId = _games.Max(g => g.Id) + 1;
			game.Id = newId;
			_games.Add(game);

			return game;

		}

		public IEnumerable<Game> GetGames(int teamId)
		{
			return _games.Where(g => g.HomeTeamId == teamId || g.AwayTeamId == teamId);
		}

		private void FillData()
		{
			_games = new List<Game>();

			Add(new Game(new DateTime(2020, 12, 12), 13, 12, 0, 0)); // Manchester United vs Manchester City
			Add(new Game(new DateTime(2021, 2, 28), 5, 13, 0, 0));   // Chelsea vs Manchester United
			Add(new Game(new DateTime(2021, 3, 3), 6, 13, 0, 0));    // Crystal Palace vs Manchester United
			Add(new Game(new DateTime(2021, 3, 7), 12, 13, 0, 2));   // Manchester City vs Manchester United
			Add(new Game(new DateTime(2021, 3, 14), 13, 19));		// Manchester United vs West Ham United
			Add(new Game(new DateTime(2021, 4, 3), 13, 3));			// Manchester United vs Brighton
			Add(new Game(new DateTime(2021, 4, 10), 17, 13));		// Tottenham vs Manchester United
		}
	}
}
