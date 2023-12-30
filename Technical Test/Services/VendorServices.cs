using Technical_Test.Contracts;
using Technical_Test.DTOs.Company;
using Technical_Test.Models;
using Technical_Test.Repositories;

namespace Technical_Test.Services
{
    public class VendorServices
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorServices(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

    }
}
