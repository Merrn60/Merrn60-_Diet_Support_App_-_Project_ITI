using IV.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IV.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
         
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        public float? Height { get; set; }

        public string? Gender { get; set; }

        public ICollection<MotivationalQuote>? MotivationalQuotes { get; set; }
        public ICollection<CalorieCalculation>? CalorieCalculations { get; set; }
        public ICollection<InspirationalVideo>? InspirationalVideos { get; set; }
    }
}
