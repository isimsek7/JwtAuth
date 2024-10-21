using System;
using System.ComponentModel.DataAnnotations;

namespace JwtAuth.Dtos
{
	public class LoginDto
	{
		public LoginDto()
		{
		}

		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

