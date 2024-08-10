using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IOperatorRepository : IRepository<Operator>
{
	Task<Operator> GetByIdAsync(int operatorId);
	Task<List<Operator>> GetOperatorsByNameAsync(string operatorName);
}