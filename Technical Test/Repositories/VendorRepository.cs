using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.Models;

namespace Technical_Test.Repositories
{
    public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(BookingDbContext context) : base(context)
        {

        }
    }
}
