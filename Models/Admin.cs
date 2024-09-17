using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IV.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(100)]
        public string? Name { get; }  


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<InspirationalVideo> InspirationalVideos { get; set; } = new List<InspirationalVideo>();
        public ICollection<MotivationalQuote> MotivationalQuotes { get; set; } = new List<MotivationalQuote>();
        public ICollection<CalorieCalculation> CalorieCalculations { get; set; } = new List<CalorieCalculation>();
    }
}
