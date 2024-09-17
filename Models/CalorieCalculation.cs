using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IV.Models
{
    public class CalorieCalculation
    {
        [Key]
        public int ID { get; set; }

        public int RecommendedCalories { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [Range(1, 300)]
        public double Height { get; set; }

        [Required]
        [Range(1, 500)]
        public double Weight { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        public double DailyCalories { get; set; }

       
    }
}