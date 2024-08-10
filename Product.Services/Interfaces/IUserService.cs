using Product.Domain.Entity;
using Product.Services.Dto;

namespace Product.Services.Interfaces;

public interface IUserService
{
	Task CreateAsync(User user);
	Task<User> GetByIdAsync(int userId);
	Task UpdateAsync(User user);
	Task DeleteAsync(User user);
	Task<User> GetByEmailAsync(string email);
	void MapUserToUpdate(UserRegistrationByInviteDto dto, User user);
}
