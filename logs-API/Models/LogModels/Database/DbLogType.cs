using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text.Json;
using System.Text.Json.Serialization;

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
        public string Styles { get; set; } = JsonSerializer.Serialize(new LogStyle());
        [Required]
        [ForeignKey("DbProject")]
        public int ProjectId { get; set; }
        public DbProject Project { get; set; }
        public virtual ICollection<DbLog> Logs { get; set; }
    }
}
