using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column("Season_ID")]
        public int Season_ID { get; set; }

        [Required]
        [Column("Track_ID")]
        public int Track_ID { get; set; }

        [Required]
        public DateTime Race_Date { get; set; }

        [ForeignKey("Season_ID")]
        public Season Season { get; set; }

        [ForeignKey("Track_ID")]
        public Track Track { get; set; }
    }
}
