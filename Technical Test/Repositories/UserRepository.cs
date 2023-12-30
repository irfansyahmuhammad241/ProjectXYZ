using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.Models;
using Technical_Test.Utilities.Enums;

namespace Technical_Test.Repositories
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(BookingDbContext context) : base(context)
        {

        }

        public User? GetByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email);
        }

        public User? GetByUserType(UserType userType)
        {
            return _context.Set<User>().FirstOrDefault(u => u.UserType == userType);
        }
    }
    
}

