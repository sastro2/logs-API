using logs_API.Data;

namespace logs_API.Interfaces
{
    public interface IProjects
    {
        public Task CreateProject(DataContext context, int userId);
        public Task DeleteProject(DataContext context);

    }
}
