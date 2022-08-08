using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Models.LogModels.Database;

namespace logs_API.Repo
{
    public class ProjectRepo : IProjects
    {
        public async Task CreateProject(DataContext context, int userId)
        {
            DbUser? user = context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return;

            DbProject newProject = new();

            newProject.Users.Add(user);
            context.Projects.Add(newProject);
            user.Projects.Add(newProject);

            await context.SaveChangesAsync();
        }

        public async Task DeleteProject(DataContext context)
        {
            throw new NotImplementedException();
        }
    }
}
