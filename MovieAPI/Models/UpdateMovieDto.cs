using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class UpdateMovieDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
