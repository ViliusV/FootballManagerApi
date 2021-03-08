using System;

namespace Entities
{
	public class Game: Entity
	{

		public DateTime Date { get; set; }
		public int HomeTeamId { get; set; }
		public int AwayTeamId { get; set; }
		public int HomeTeamScore { get; set; }
		public int AwayTeamScore { get; set; }

		public Game(DateTime date, int homeTeamId, int awayTeamId)
		{
			Date = date;
			HomeTeamId = homeTeamId;
			AwayTeamId = awayTeamId;
		}

		public Game(DateTime date, int homeTeamId, int awayTeamId, int homeTeamScore, int awayTeamScore)
		{
			Date = date;
			HomeTeamId = homeTeamId;
			AwayTeamId = awayTeamId;
			HomeTeamScore = homeTeamScore;
			AwayTeamScore = awayTeamScore;
		}
	}
}
