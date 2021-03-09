using System.Security.Claims;

namespace API.Utilities
{
	public static class UserIdentityUtility
	{
		public static int? GetUserTeamId(this ClaimsPrincipal user)
		{
			if (user?.Identity is ClaimsIdentity identity)
			{
				var teamIdValue = identity.FindFirst("teamId").Value;
				if (int.TryParse(teamIdValue, out int teamId))
				{
					return teamId;
				}
				else
				{
					return null;
				}
			}

			return null;
		}
	}
}
