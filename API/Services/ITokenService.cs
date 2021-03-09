using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
	public interface ITokenService
	{
		string CreateToken(string email, string password);
	}
}
