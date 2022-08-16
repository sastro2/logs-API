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
            modelBuilder.Entity<DbUserJourney>().HasMany(u => u.DbLogs).WithOne(l => l.UserJourney);
            modelBuilder.Entity<DbLogType>().HasMany(t => t.Logs).WithOne(l => l.LogType);
            modelBuilder.Entity<DbUser>().HasMany(u => u.Projects).WithMany(p => p.Users);
            modelBuilder.Entity<DbProject>().HasMany(p => p.LogTypes).WithOne(t => t.Project);
        }
    }
}
