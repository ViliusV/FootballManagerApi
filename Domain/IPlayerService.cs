using Entities;
using System.Collections.Generic;

namespace Domain
{

	public interface IPlayerService
	{
		IEnumerable<Player> GetAll();
		Player Get(int id);
		IEnumerable<Player> GetTeamPlayers(int teamId);
		Player CreatePlayer(Player player);
		Player UpdatePlayer(Player player);
		bool DeletePlayer(int playerId);
		Player AddPlayerToTheTeam(int teamId, int playerId, int jerseyNumber);
		bool RemovePlayerFromTheTeam(int teamId, int playerId);
	}
}
