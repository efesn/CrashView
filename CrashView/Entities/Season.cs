using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Season
    {
        [Key]
        public int Season_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Season_Name { get; set; }

        [Required]
        public DateTime Start_Date { get; set; }

        [Required]
        public DateTime End_Date { get; set; }
    }
}
