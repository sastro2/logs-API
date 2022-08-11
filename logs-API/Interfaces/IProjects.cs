using logs_API.Data;
using logs_API.Models.LogModels.Database;

namespace logs_API.Interfaces
{
    public interface IProjects
    {
        public Task CreateProject(DataContext context, int userId);
        public Task DeleteProject(DataContext context, int projectId);
        public Task AddUserToProject(DataContext context, int userId, int projectId);
        public Task GetSingleProjectById(DataContext context, int projectId);
        public IEnumerable<DbProject> GetAllProjectsForUserById(DataContext context, int userId);
    }
}
