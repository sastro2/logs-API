using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logs_API.Models.LogModels.Database
{
    public class DbUserJourney
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("DbProject")]
        public int ProjectId { get; set; }
        [Required]
        public int Timestamp { get; set; }

        public virtual ICollection<DbLog>? DbLogs { get; set; }
    }
}
