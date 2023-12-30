using Technical_Test.Contracts;

namespace Technical_Test.Services
{
    public class ManagerLogisticsServices
    {
        private readonly IManagerLogistics _managerLogistics;

        public ManagerLogisticsServices(IManagerLogistics managerLogistics)
        {
            _managerLogistics = managerLogistics;

        }
    }
}
