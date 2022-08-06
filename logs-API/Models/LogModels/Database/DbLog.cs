using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logs_API.Models.LogModels.Database
{
    public class DbLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserJourneys")]
        public int UserJourneyId { get; set; }

        public virtual DbUserJourney? UserJourney { get; set; }
        [Required]
        [ForeignKey("DbLogType")]
        public int LogTypeId { get; set; }
        public virtual DbLogType? LogType { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
