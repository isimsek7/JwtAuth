﻿using System;
using System.ComponentModel.DataAnnotations;

namespace JwtAuth.Dtos
{
	public class RegisterDto
	{
		public RegisterDto()
		{
		}
		[Required]
		public string? Username { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
	}
}

