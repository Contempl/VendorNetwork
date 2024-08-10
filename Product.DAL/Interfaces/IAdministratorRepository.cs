using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IAdministratorRepository : IRepository<Administrator>
{
	Task<Administrator> GetByIdAsync(int adminId);
}