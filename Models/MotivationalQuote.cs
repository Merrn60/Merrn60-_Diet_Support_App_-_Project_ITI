using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IV.Models
{
    public class MotivationalQuote
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }
        public bool IsFavorite { get; set; } // Add this property
        [ForeignKey("User")]
        public int? UserID { get; set; }  // استخدام نوع Nullable
        public User User { get; set; }


 

    }
}