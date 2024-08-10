using Product.DAL.Interfaces;
using Product.Domain.Entity;
using Product.Services.Dto;
using Product.Services.Interfaces;

namespace Product.Services.Implementations;

public class OperatorUserService : IOperatorUserService
{
    private readonly IOperatorUserRepository _operatorUserRepository;

    public OperatorUserService(IOperatorUserRepository operatorUserRepository)
    {
        _operatorUserRepository = operatorUserRepository;
    }

    public Task CreateAsync(OperatorUser operatorUser) => _operatorUserRepository.CreateAsync(operatorUser);
    public Task DeleteAsync(OperatorUser operatorUser) => _operatorUserRepository.DeleteAsync(operatorUser);
    public Task<OperatorUser> GetByIdAsync(int id) => _operatorUserRepository.GetByIdAsync(id);
    public Task UpdateAsync(OperatorUser vendor) => _operatorUserRepository.UpdateAsync(vendor);
    public OperatorUser MapOperatorUserFromDto(UserRegistrationDto registrationData) => new OperatorUser
    {
        UserName = registrationData.UserName,
        FirstName = registrationData.FirstName,
        LastName = registrationData.LastName,
        Email = registrationData.Email,
        PasswordHash = HashThePassword(registrationData.Password)
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
