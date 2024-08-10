using Microsoft.EntityFrameworkCore;
using Product.DAL.Interfaces;
using Product.Domain.Entity;
using Product.Services.Dto;
using Product.Services.Interfaces;

namespace Product.Services.Implementations;

public class InviteService : IInviteService
{
	private IInviteRepository _inviteRepository;

	public InviteService(IInviteRepository inviteRepository)
	{
		_inviteRepository = inviteRepository;
	}

	public async Task CreateAsync(Invite invite) => await _inviteRepository.CreateAsync(invite);
	public async Task DeleteAsync(Invite invite) => await _inviteRepository.DeleteAsync(invite);
	public async Task<Invite> GetByIdAsync(int inviteId) => await _inviteRepository.GetByIdAsync(inviteId);
	public void ValidateInvite(Invite invite)
	{
		if (invite.ExpiresAt < DateTime.UtcNow)
		{
			throw new Exception($"Invitation expired. Invite id: {invite.Id}");
		}

		if (invite.Status != InvitationStatus.Sent)
		{
			throw new Exception($"Invalid invitation. Invite id: {invite.Id}");
		}
	}
	public async Task<Invite> GetInviteWithUserAsync(int inviteId)
	{
		var invite = await _inviteRepository.GetAll()
			.Where(i => i.Id == inviteId)
			.Include(i => i.User)
			.FirstAsync();

		return invite;
	}
	public async Task UpdateAsync(Invite invite) => await _inviteRepository.UpdateAsync(invite);
	public void UpdateInvitationStatusAsync(User user, Invite invite, UserRegistrationByInviteDto dto)
	{
		invite.Status = InvitationStatus.Accepted;

		user.InviteId = dto.InviteId;
		user.UserName = dto.UserName;
		user.FirstName = dto.FirstName;
		user.LastName = dto.LastName;
		user.PasswordHash = HashThePassword(dto.Password);
	}
	public Invite CreateInvite(User user, Administrator admin) => new Invite
	{
		User = user,
		UserId = user.Id,
		Status = InvitationStatus.Sent,
		CreatedAt = DateTime.UtcNow,
		ExpiresAt = DateTime.UtcNow.AddDays(30),
		AdminId = admin.Id,
		Admin = admin
	};
	private byte[] HashThePassword(string password)
	{
		using (var hmac = new System.Security.Cryptography.HMACSHA512())
		{
			var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			return passwordHash;
		}
	}
}
