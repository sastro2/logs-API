using logs_API.Data;

namespace logs_API.Interfaces.LogsInterface
{
    public interface IProjects
    {
        public Task CreateProject(DataContext context);
        public Task DeleteProject(DataContext context);

    }
}
