using Product.DAL.Interfaces;
using Product.Domain.Entity;
using Product.Services.Dto;
using Product.Services.Interfaces;

namespace Product.Services.Implementations;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public Task CreateAsync(User user) => _userRepository.CreateAsync(user);
	public Task DeleteAsync(User user) => _userRepository.DeleteAsync(user);
	public Task<User> GetByIdAsync(int userId) => _userRepository.GetByIdAsync(userId);
	public Task UpdateAsync(User user) => _userRepository.UpdateAsync(user);
	public Task<User> GetByEmailAsync(string email) => _userRepository.GetByEmailAsync(email);
	public void MapUserToUpdate(UserRegistrationByInviteDto dto, User user)
	{
		user.UserName = dto.UserName;
		user.FirstName = dto.FirstName;
		user.LastName = dto.LastName;
		user.PasswordHash = HashThePassword(dto.Password);
	}
	private byte[] HashThePassword(string password)
	{
		using (var hmac = new System.Security.Cryptography.HMACSHA512())
		{
			var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			return passwordHash;
		}
	}
}
