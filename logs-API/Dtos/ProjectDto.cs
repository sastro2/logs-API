using System.ComponentModel.DataAnnotations;

namespace logs_API.Dtos
{
    public class ProjectDto
    {
        [Required]
        public int Id { get; set; }
    }
}
