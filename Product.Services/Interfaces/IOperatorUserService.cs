using Product.Domain.Entity;
using Product.Services.Dto;

namespace Product.Services.Interfaces;

public interface IOperatorUserService
{
    Task CreateAsync(OperatorUser operatorUser);
    Task<OperatorUser> GetByIdAsync(int operatorServiceId);
    Task UpdateAsync(OperatorUser operatorUser);
    Task DeleteAsync(OperatorUser operatorUser);
    OperatorUser MapOperatorUserFromDto(UserRegistrationDto registrationData);
}
