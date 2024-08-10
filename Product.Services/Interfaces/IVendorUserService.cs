using Product.Domain.Entity;
using Product.Services.Dto;

namespace Product.Services.Interfaces;

public interface IVendorUserService
{
    Task CreateAsync(VendorUser vendorUser);
    Task<VendorUser> GetByIdAsync(int vendorUserId);
    Task UpdateAsync(VendorUser vendorUser);
    Task DeleteAsync(VendorUser vendorUser);
    VendorUser MapVendorUserFromDto(UserRegistrationDto registrationData);
}
