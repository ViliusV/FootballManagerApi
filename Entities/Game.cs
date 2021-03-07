using System;

namespace Entities
{
	public class Game
	{
		public DateTime Date { get; set; }
		public Team HomeTeam { get; set; }
		public Team AwayTeam { get; set; }
		public int HomeTeamScore { get; set; }
		public int AwayTeamScore { get; set; }
	}
}
