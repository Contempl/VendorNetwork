using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IVendorUserRepository : IRepository<VendorUser>
{
	Task<VendorUser> GetByIdAsync(int vendorId);
}