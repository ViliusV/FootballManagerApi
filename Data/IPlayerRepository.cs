using Entities;

namespace Data
{
	public interface IPlayerRepository
	{
		Player Get(int id);
		Player Add(Player player);
		Player Update(Player player);
		bool Remove(int id);
	}
}
