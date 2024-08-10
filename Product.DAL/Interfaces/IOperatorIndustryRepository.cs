using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IOperatorIndustryRepository : IRepository<OperatorIndustry>
{
	Task<OperatorIndustry> GetByIdAsync(int operatorId, int industryId);
}