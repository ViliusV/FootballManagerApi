using Entities;
using System.Collections.Generic;
using System.Text;

namespace Domain
{

	public interface IPlayerService
	{
		IEnumerable<Player> GetTeamPlayers(int teamId);
		Player SavePlayer(Player player);
		bool DeletePlayer(int playerId);
		Player AddPlayerToTheTeam(int teamId, int playerId, int jerseyNumber);
		bool RemovePlayerFromTheTeam(int playerId);
	}
}
