using System.Data;
using System.Security.Claims;
using Technical_Test.Models;
using Technical_Test.Utilities.Enums;

namespace Technical_Test.Contracts
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        public User? GetByEmail(string email);
        public User? GetByUserType(UserType userType);
    }
}
