using API.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private readonly ITokenService _tokenService;

		public SignInController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost()]
		public ActionResult<string> SignIn(LoginDto model)
		{
			var token = _tokenService.CreateToken(model.Username, model.Password);
			if (string.IsNullOrEmpty(token))
			{
				return Unauthorized("User does not exist with such password");
			}

			return token;
		}
	}
}
