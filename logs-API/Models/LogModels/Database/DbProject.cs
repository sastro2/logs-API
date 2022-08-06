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
        public List<DbUser>? DbUsers { get; set; }
        public virtual ICollection<DbUser>? Users { get; set; } 
        public List<DbLogType>? DbTypes { get; set; }
        public virtual ICollection<DbLogType>? Types { get; set; }
    }
}
