using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Models.LogModels.Database;

namespace logs_API.Repo
{
    public class UserRepo : IUsers
    {
        public async Task CreateUser(DataContext context, string username, string password)
        {
            DbUser? user = context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null)
                return;

            DbUser newUser = new() { UserName = username, Password = password };
            context.Users.Add(newUser);

            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(DataContext context, int id)
        {
            throw new NotImplementedException();
        }
    }
}
