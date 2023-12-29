using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.Models;

namespace Technical_Test.Repositories
{
    public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(BookingDbContext context) : base(context)
        {
        }
    }
}
