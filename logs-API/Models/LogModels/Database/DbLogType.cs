using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logs_API.Models.LogModels.Database
{
    public class DbLogType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool SendImmediately { get; set; }
        [Required]
        [ForeignKey("DbProject")]
        public int ProjectId { get; set; }
    }
}
