using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
	public class GameService : IGameService
	{
		private readonly IGameRepository _gameRepository;

		public GameService(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}

		public IEnumerable<Game> GetAllPreviousGames(int teamId)
		{
			var allGames = _gameRepository.GetGames(teamId);
			return allGames.Where(g => g.Date < DateTime.UtcNow);
		}

		public IEnumerable<Game> GetAllUpcomingGames(int teamId)
		{
			var allGames = _gameRepository.GetGames(teamId);
			return allGames.Where(g => g.Date >= DateTime.UtcNow);
		}
	}
}
