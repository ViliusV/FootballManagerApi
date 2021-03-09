using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
	public class TokenService : ITokenService
	{
		private readonly SymmetricSecurityKey _securityKey;

		public TokenService(IConfiguration config)
		{
			_securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["JwtTokenKey"]));
		}

		public string CreateToken(string email, string password)
		{
			//ToDo: Move user sign in logic elsewhere after we start storing users and their password hashes
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !password.Equals("password"))
			{
				return null;
			}

			var teamId = email switch
			{
				"ogs@manutd.com" => 13,
				"pg@mancity.com" => 12,
				"jm@tottenham.com" => 17,
				_ => 0
			};


			if (teamId == 0)
			{
				return null;
			}

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, email),
				new Claim("teamId", teamId.ToString())
			};


			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
