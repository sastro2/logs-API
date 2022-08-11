using System.ComponentModel.DataAnnotations;

namespace logs_API.Dtos
{
    public class TypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool SendImmediately { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
