using logs_API.Data;
using logs_API.Interfaces;

namespace logs_API.Repo
{
    public class UserRepo : IUsers
    {
        public async Task CreateUser(DataContext context, string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(DataContext context, int id)
        {
            throw new NotImplementedException();
        }
    }
}
