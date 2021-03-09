using Data;
using Entities;
using Moq;
using Xunit;

namespace Domain.Tests
{
	public class PlayerServiceTests
	{
		private Mock<IPlayerRepository> _playerRepository;
		private Mock<ITeamRepository> _teamRepository;
		private IPlayerService _playerService;

		[Fact]
		public void ShouldNot_HaveJerseyNumber_AfterRemovedFromTeam()
		{
			//Arrange
			var team = new Team(1, "AC Milan");
			var player = new Player("John", "Doe", 5, team.Id);

			_teamRepository = new Mock<ITeamRepository>();
			_playerRepository = new Mock<IPlayerRepository>();

			_teamRepository.Setup(x => x.Get(team.Id)).Returns(team);

			_playerRepository.Setup(x => x.Get(player.Id)).Returns(player);

			_playerService = new PlayerService(_playerRepository.Object, _teamRepository.Object);

			//Act
			var isRemoved = _playerService.RemovePlayerFromTheTeam(team.Id, player.Id);

			//Assert
			Assert.True(isRemoved);
			Assert.Null(player.JerseyNumber);
		}
	}
}
