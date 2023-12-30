using Technical_Test.Contracts;

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
