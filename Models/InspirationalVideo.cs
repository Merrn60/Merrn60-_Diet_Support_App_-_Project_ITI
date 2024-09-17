using IV.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IV.Models
{
    public class InspirationalVideo
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [Url]
        public string URL { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}