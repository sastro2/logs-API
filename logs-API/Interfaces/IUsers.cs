using logs_API.Data;

namespace logs_API.Interfaces
{
    public interface IUsers
    {
        public Task CreateUser(DataContext context, string username, string password);
        public Task DeleteUser(DataContext context,  int id);
    }
}
