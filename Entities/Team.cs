using System.Collections.Generic;

namespace Entities
{
	public class Team
	{
		public string Name { get; set; }
		public ICollection<Player> Players { get; set; }
		public ICollection<Game> Games { get; set; }
	}
}
