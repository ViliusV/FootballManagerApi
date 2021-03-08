using Entities;
using System.Collections.Generic;

namespace Domain
{
	public interface IGameService
	{
		IEnumerable<Game> GetAllUpcomingGames(int teamId);

		IEnumerable<Game> GetAllPreviousGames(int teamId);
	}
}
