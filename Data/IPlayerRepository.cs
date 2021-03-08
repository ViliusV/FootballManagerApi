using Entities;
using System.Collections.Generic;

namespace Data
{
	public interface IPlayerRepository
	{
		IEnumerable<Player> GetAll();
		Player Get(int id);
		Player Add(Player player);
		Player Update(Player player);
		bool Remove(int id);
	}
}
