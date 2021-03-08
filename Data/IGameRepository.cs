using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public interface IGameRepository
	{
		Game Add(Game game);
		IEnumerable<Game> GetGames(int teamId);
	}
}
