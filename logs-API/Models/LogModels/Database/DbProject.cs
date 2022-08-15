using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logs_API.Models.LogModels.Database
{
    public class DbProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public DbProject()
        {
            this.Users = new HashSet<DbUser>();
        }
        public virtual ICollection<DbUser> Users { get; set; }
        public virtual ICollection<DbLogType> LogTypes { get; set; }
    }
}
