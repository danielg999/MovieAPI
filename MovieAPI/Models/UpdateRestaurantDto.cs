using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class UpdateRestaurantDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Range(1900, 2100)]
        public int Year { get; set; }
    }
}
