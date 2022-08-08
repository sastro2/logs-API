using logs_API.Models.LogModels.Database;
using Microsoft.EntityFrameworkCore;

namespace logs_API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DbLog> Logs { get; set; }
        public DbSet<DbLogType> Types { get; set; }
        public DbSet<DbUserJourney> UserJourneys { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbProject> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
