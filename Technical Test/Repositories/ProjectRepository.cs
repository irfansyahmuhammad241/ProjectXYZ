using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.Models;

namespace Technical_Test.Repositories
{
    public class ProjectRepository : GeneralRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BookingDbContext context) : base(context)
        {
        }
    }

}
