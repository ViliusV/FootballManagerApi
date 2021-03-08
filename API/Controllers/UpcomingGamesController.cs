using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/team/games/[controller]")]
	[ApiController]
	public class UpcomingGamesController : ControllerBase
	{
		private readonly IGameService _gameService;

		public UpcomingGamesController(IGameService gameService)
		{
			_gameService = gameService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var games = _gameService.GetAllUpcomingGames(13);	//ToDo: use user's team
																//ToDo: Return DTO
			return Ok(games);
		}
	}
}
