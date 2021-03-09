using API.DTO;
using API.Utilities;
using Domain;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
	[Route("api/team/players")]
	[ApiController]
	[Authorize]
	public class TeamPlayersController : ControllerBase
	{
		private readonly IPlayerService _playerService;

		public TeamPlayersController(IPlayerService playerService)
		{
			_playerService = playerService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Player>> GetAll()
		{
			var teamId = HttpContext.User.GetUserTeamId();
			if (teamId == null)
			{
				return BadRequest("Current user does not manage a team");
			}

			var players = _playerService.GetTeamPlayers(teamId.Value);

			return Ok(players);
		}

		[HttpPost]
		public IActionResult AddPlayer(TeamPlayerAddDto model)
		{
			var teamId = HttpContext.User.GetUserTeamId();
			if (teamId == null)
			{
				return BadRequest("Current user does not manage a team");
			}

			var player = _playerService.Get(model.Id);
			if (player == null)
			{
				return NotFound("Player does not exist");
			}

			var updatedPlayer = _playerService.AddPlayerToTheTeam(teamId.Value, player.Id, model.JerseyNumber);
			if (updatedPlayer != null)
			{
				return Ok(updatedPlayer);
			}

			return BadRequest("Player was not included in the team");
		}

		[HttpDelete("{id}")]
		public IActionResult RemovePlayer(int id)
		{
			var teamId = HttpContext.User.GetUserTeamId();
			if (teamId == null)
			{
				return BadRequest("Current user does not manage a team");
			}

			var player = _playerService.Get(id);
			if (player == null)
			{
				return NotFound();
			}

			var isRemoved = _playerService.RemovePlayerFromTheTeam(teamId.Value, id);
			if (isRemoved)
			{
				return Ok();
			}

			return BadRequest("Player was not removed from the team");
		}
	}
}
