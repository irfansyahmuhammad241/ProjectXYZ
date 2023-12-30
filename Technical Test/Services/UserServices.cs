using Technical_Test.Contracts;

namespace Technical_Test.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
    }
}
