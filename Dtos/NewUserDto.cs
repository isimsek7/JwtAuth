using System;
namespace JwtAuth.Dtos
{
	public class NewUserDto
	{
		public NewUserDto()
		{
		}
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}

