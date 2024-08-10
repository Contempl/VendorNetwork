﻿using Product.Domain.Entity;
using Product.Services.Dto;

namespace Product.Services.Interfaces;

public interface IVendFacilityService
{
    Task CreateAsync(VendorFacility vendorFacility);
    Task<VendorFacility> GetByIdAsync(int vendorFacilityId, int vendorId);
    Task<VendorFacility> GetFacilityWithServicesByIdAsync(int vendorFacilityId, int vendorId);
	Task UpdateAsync(VendorFacility vendorFacility);
    Task DeleteAsync(VendorFacility vendorFacility);
    VendorFacility MapVendorFacilityFromDtoToCreateAsync(Vendor vendor, VendorFacilityDto facilityData);
    Task MapAndUpdateVendorFacility(VendorFacility facility, UpdateVendorFacilityDto facilityData);
}
