using System.ComponentModel.DataAnnotations;

namespace logs_API.Dtos
{
    public class TypeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool SendImmediately { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string Styles { get; set; } = string.Empty;
    }
}
