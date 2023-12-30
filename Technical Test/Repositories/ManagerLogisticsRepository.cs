using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.Models;

namespace Technical_Test.Repositories
{
    public class ManagerLogisticsRepository : GeneralRepository<ManagerLogistics>, IManagerLogistics
    {
        public ManagerLogisticsRepository(BookingDbContext context) : base(context)
        {
        }
    }
}
