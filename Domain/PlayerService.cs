using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
	public class PlayerService : IPlayerService
	{
		private readonly IPlayerRepository _playerRepository;
		private readonly ITeamRepository _teamRepository;

		public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository)
		{
			_playerRepository = playerRepository;
			_teamRepository = teamRepository;
		}

		public Player AddPlayerToTheTeam(int teamId, int playerId, int jerseyNumber)
		{
			var team = _teamRepository.Get(teamId);
			if (team == null)
			{
				throw new ArgumentException($"Team with Id=={teamId} does not exist");
			}

			var player = _playerRepository.Get(playerId);
			if (player == null)
			{
				throw new ArgumentException($"Player with Id=={playerId} does not exist");
			}

			var teamPlayers = GetTeamPlayers(teamId);
			var existingTeamPlayer = teamPlayers.SingleOrDefault(p => p.JerseyNumber == jerseyNumber);
			if (existingTeamPlayer != null)
			{
				throw new ArgumentException($"Jersey #{jerseyNumber} belongs to (ID:{existingTeamPlayer.Id}) {existingTeamPlayer.FirstName} {existingTeamPlayer.LastName}");
			}

			player.TeamId = teamId;
			player.JerseyNumber = jerseyNumber;

			_playerRepository.Update(player);

			return player;

		}

		public bool DeletePlayer(int playerId)
		{
			return _playerRepository.Remove(playerId);
		}

		public IEnumerable<Player> GetTeamPlayers(int teamId)
		{
			var allPlayers = _playerRepository.GetAll();
			return allPlayers.Where(p => p.TeamId == teamId);
		}

		public bool RemovePlayerFromTheTeam(int playerId)
		{
			var player = _playerRepository.Get(playerId);
			if (player == null)
			{
				throw new ArgumentException($"Player with Id=={playerId} does not exist");
			}

			player.JerseyNumber = null;
			player.TeamId = null;

			return true;
		}

		public Player SavePlayer(Player player)
		{
			return _playerRepository.Add(player);
		}
	}
}
