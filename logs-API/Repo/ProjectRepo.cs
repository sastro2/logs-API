using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Models.LogModels.Database;
using System.Diagnostics;

namespace logs_API.Repo
{
    public class ProjectRepo : IProjects
    {
        public async Task AddUserToProject(DataContext context, int userId, int projectId)
        {
            DbUser? user = context.Users.FirstOrDefault(u => u.Id == userId);
            DbProject? project = context.Projects.FirstOrDefault(p => p.Id == projectId);

            if (user == null || project == null)
                return;

            project.Users.Add(user);
            user.Projects.Add(project);

            await context.SaveChangesAsync();
        }

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

        public async Task DeleteProject(DataContext context, int projectId)
        {
            DbProject? project = context.Projects.FirstOrDefault(p => p.Id == projectId);

            if (project == null)
                return;

            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public IEnumerable<DbProject> GetAllProjectsForUserById(DataContext context, int userId)
        {
            DbUser? user = context.Users.FirstOrDefault(u => u.Id == userId);
            IEnumerable<DbProject> projects = new List<DbProject>();

            if (user == null)
                return projects;

            projects = user.Projects;
            Debug.WriteLine(context.Projects.First().Users);
            return projects;
        }

        public Task GetSingleProjectById(DataContext context, int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
