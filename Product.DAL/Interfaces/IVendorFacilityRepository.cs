using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IVendorFacilityRepository : IRepository<VendorFacility>
{
	Task<VendorFacility> GetByIdAsync(int facilityId, int vendorId);
	Task<VendorFacility> GetFacilityWithServicesByIdAsync(int vendorFacilityId, int vendorId);
}