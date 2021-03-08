using System.Collections.Generic;

namespace Entities
{
	public class Team: Entity
	{
		public string Name { get; set; }
		public ICollection<Player> Players { get; set; }
		public ICollection<Game> Games { get; set; }


		public Team(int id, string name)
		{
			Id = id;
			Name = name;
			Players = new List<Player>();
			Games = new List<Game>();
		}
	}
}
