using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IOperatorUserRepository : IRepository<OperatorUser>
{
	Task<OperatorUser> GetByIdAsync(int operatorId);
}