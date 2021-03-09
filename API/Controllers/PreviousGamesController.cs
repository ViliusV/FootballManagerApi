using API.Utilities;
using Domain;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
	[Route("api/team/games/[controller]")]
	[ApiController]
	[Authorize]
	public class PreviousGamesController : ControllerBase
	{
		private readonly IGameService _gameService;

		public PreviousGamesController(IGameService gameService)
		{
			_gameService = gameService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Game>> GetAll()
		{
			var teamId = HttpContext.User.GetUserTeamId();

			if (teamId == null)
			{
				return BadRequest("Current user does not manage a team");
			}

			var games = _gameService.GetAllPreviousGames(teamId.Value); //ToDo: Return DTO

			return Ok(games);
		}
	}
}
