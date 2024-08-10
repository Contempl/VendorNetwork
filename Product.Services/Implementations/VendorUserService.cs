using Product.DAL.Interfaces;
using Product.Domain.Entity;
using Product.Services.Dto;
using Product.Services.Interfaces;

namespace Product.Services.Implementations;

public class VendorUserService : IVendorUserService
{
    private readonly IVendorUserRepository _vendorUserRepository;

    public VendorUserService(IVendorUserRepository vendorUserRepository)
    {
        _vendorUserRepository = vendorUserRepository;
    }

    public Task CreateAsync(VendorUser vendor) => _vendorUserRepository.CreateAsync(vendor);
    public Task DeleteAsync(VendorUser vendorUser) => _vendorUserRepository.DeleteAsync(vendorUser);
    public Task<VendorUser> GetByIdAsync(int id) => _vendorUserRepository.GetByIdAsync(id);
    public Task UpdateAsync(VendorUser vendor) => _vendorUserRepository.UpdateAsync(vendor);
    public VendorUser MapVendorUserFromDto(UserRegistrationDto registrationData) => new VendorUser()
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
