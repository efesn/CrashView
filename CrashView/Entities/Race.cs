using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Race
    {
        [Key]
        public int Race_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Race_Name { get; set; }

        [Required]
        public int Season_ID { get; set; }

        [Required]
        public int Track_ID { get; set; }

        [Required]
        public DateTime Race_Date { get; set; }

        public Season Season { get; set; }
        public Track Track { get; set; }
    }
}
