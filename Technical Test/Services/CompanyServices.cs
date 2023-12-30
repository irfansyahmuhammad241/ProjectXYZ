using Technical_Test.Contracts;

namespace Technical_Test.Services
{
    public class CompanyServices
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

        }
    }
}
