using Microsoft.AspNetCore.Mvc;
using Product.DAL;
using Product.Domain.Entity;
using Product.Services.Dto;
using Product.Services.Filters;
using Product.Services.Interfaces;

namespace Product.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IInviteService _inviteService;
	private readonly IOperatorUserService _operatorUserService;
	private readonly IVendorUserService _vendorUserService;
	private readonly IAdministratorService _adminService;
	private readonly AppDbContext _dbContext;

	public AccountController(IInviteService inviteService, IVendorUserService vendorUserService,
		IOperatorUserService operatorUserService, IUserService userService, IAdministratorService adminService, AppDbContext dbContext)
	{
		_inviteService = inviteService;
		_vendorUserService = vendorUserService;
		_operatorUserService = operatorUserService;
		_userService = userService;
		_adminService = adminService;
		_dbContext = dbContext;
	}

	[HttpGet("Register/User/{inviteId}")]
	[EnsureInviteExists]
	public async Task<IActionResult> RegisterUser (int inviteId)
	{
		var invite = await _inviteService.GetByIdAsync(inviteId);

		_inviteService.ValidateInvite(invite);

		var newUser = new UserRegistrationDto { InviteId = inviteId };
		return Ok(newUser);
	}


	[HttpPost("Register/User/{inviteId}")]
	[EnsureInviteExists]
	public async Task<IActionResult> RegisterUserByInvite (int inviteId, 
		[FromBody] UserRegistrationByInviteDto registrationData)
	{
		var invite = await _inviteService.GetInviteWithUserAsync(inviteId);

		_inviteService.ValidateInvite(invite);

		registrationData.InviteId = inviteId; 
		await UpdateInviteAndUser(registrationData, invite);

		return CreatedAtAction(nameof(GetUser), new { userId = invite.UserId }, registrationData);
	}

	[HttpPost("Register/User")]
	public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto registrationData)
	{
		if (!registrationData.IsOperator)
		{
			var newVendor = _vendorUserService.MapVendorUserFromDto(registrationData);

			await _vendorUserService.CreateAsync(newVendor);
			return CreatedAtAction(nameof(GetUser), new { id = newVendor.Id }, registrationData);
		}
		
		var newOperator = _operatorUserService.MapOperatorUserFromDto(registrationData);

		await _operatorUserService.CreateAsync(newOperator);
		return CreatedAtAction(nameof(GetUser), new { userId = newOperator.Id }, registrationData);
	}


	[HttpGet("User/{userId}")]
	[EnsureUserExists]
	public async Task<ActionResult> GetUser(int userId)
	{
		var existingUser = await _userService.GetByIdAsync(userId);

		return Ok(existingUser);
	}

	[HttpPost("Register/User/Admin")]
	public async Task<ActionResult> RegisterAdmin(AdminRegistrationDto registrationData)
	{
		var admin = _adminService.MapAdminFromDto(registrationData);

		await _adminService.CreateAsync(admin);

		return Ok(admin);
	}

	private async Task UpdateInviteAndUser (UserRegistrationByInviteDto dto, Invite invite)
	{
		var user = await _userService.GetByIdAsync((int)invite.UserId!);

		_userService.MapUserToUpdate(dto, user);

		if (user is VendorUser vendorUser)
		{
			await _vendorUserService.UpdateAsync(vendorUser);
		}
		else if (user is OperatorUser operatorUser)
		{
			await _operatorUserService.UpdateAsync(operatorUser);
		}
		else
		{
			throw new InvalidOperationException("Unknow user type");
		}

		await _inviteService.UpdateAsync(invite);
	}
}
