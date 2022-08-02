using Microsoft.EntityFrameworkCore;
using logs_API.Models.LogModels;

namespace logs_API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DbLog> Logs { get; set; }
    }
}
