using System;
using JwtAuth.Models;

namespace JwtAuth.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}

