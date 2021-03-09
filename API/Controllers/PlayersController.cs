using API.DTO;
using Domain;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize] // ToDo: Allow super admins to call this controller's actions
	public class PlayersController : ControllerBase
	{
		private readonly IPlayerService _playerService;

		public PlayersController(IPlayerService playerService)
		{
			_playerService = playerService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Player>> Get()
		{
			return Ok(_playerService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<Player> Get(int id)
		{
			var player = _playerService.Get(id);

			if (player == null)
			{
				return NotFound();
			}

			return Ok(player);
		}

		[HttpPost]
		public ActionResult<Player> Post(PlayerDto model)
		{
			var player = new Player(model.FirstName, model.LastName, model.JerseyNumber, model.TeamId);

			var createdPlayer = _playerService.CreatePlayer(player);

			if (createdPlayer != null) 
			{
				return Created("/api/Players", createdPlayer);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public ActionResult<Player> Put(int id, PlayerDto model)
		{
			var player = _playerService.Get(id);
			if (player == null)
			{
				return NotFound();
			}

			player.FirstName = model.FirstName;
			player.LastName = model.LastName;
			player.TeamId = model.TeamId;
			player.JerseyNumber = model.JerseyNumber;


			var updatedPlayer = _playerService.UpdatePlayer(player);

			if (updatedPlayer != null)
			{
				return Ok(updatedPlayer);
			}

			return BadRequest();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var player = _playerService.Get(id);

			if (player == null)
			{
				return NotFound();
			}

			var isRemoved = _playerService.DeletePlayer(player.Id);
			if (isRemoved)
			{
				return Ok();
			}

			return BadRequest("Player was not removed from the team");
		}
	}
}
