using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.Models;

namespace Technical_Test.Repositories
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(BookingDbContext context) : base(context)
        {
        }
    }
    
}

