using Technical_Test.Contracts;

namespace Technical_Test.Services
{
    public class ProjectServices
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

        }
    }
}
