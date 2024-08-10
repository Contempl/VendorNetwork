﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Product.Services.Dto;

public class AdminRegistrationDto
{
	[Required]
	public string UserName { get; set; }

	[Required]
	[StringLength(50, ErrorMessage = "The password must be at least 6 and at max 100 characters long.",
		MinimumLength = 6)]
	[PasswordPropertyText]
	public string Password { get; set; }

	[Required, MaxLength(40, ErrorMessage = "Name shouldn't be longer than 40 symbols")]
	public string FirstName { get; set; }

	[Required, MaxLength(50, ErrorMessage = "Surname shouldn't be longer than 50 symbols")]
	public string LastName { get; set; }

	[Required]
	public string Email { get; set; }
}
