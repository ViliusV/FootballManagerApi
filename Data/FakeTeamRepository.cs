using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
	public class FakeTeamRepository : ITeamRepository
	{
		private IEnumerable<Team> _teams;

		public FakeTeamRepository()
		{
			FillData();
		}

		public Team Get(int id)
		{
			return _teams.SingleOrDefault(t => t.Id == id);
		}

		private void FillData()
		{
			_teams = new List<Team>()
			{
				new Team(1, "Arsenal"),
				new Team(2, "Aston Villa"),
				new Team(3, "Brighton & Hove Albion"),
				new Team(4, "Burnley"),
				new Team(5, "Chelsea"),
				new Team(6, "Crystal Palace"),
				new Team(7, "Everton"),
				new Team(8, "Fulham"),
				new Team(9, "Leeds United"),
				new Team(10, "Leicester City"),
				new Team(11, "Liverpool"),
				new Team(12, "Manchester City"),
				new Team(13, "Manchester United"),
				new Team(14, "Newcastle United"),
				new Team(15, "Sheffield United"),
				new Team(16, "Southampton Team"),
				new Team(17, "Tottenham Hotspur"),
				new Team(18, "West Bromwich Albion"),
				new Team(19, "West Ham United"),
				new Team(20, "Wolverhampton Wanderers")
			};
		}
	}
}
