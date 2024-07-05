using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Team
    {
        [Key]
        public int Team_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Team_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Base_Country { get; set; }
    }
}
