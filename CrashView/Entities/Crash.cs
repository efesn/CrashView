using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrashView.Entities
{
    public class Crash
    {
        [Key]
        public int Crash_ID { get; set; }
        [Required]

        [Column("Race_ID")]
        public int Race_ID { get; set; }
        [Required]
        public int Person_ID { get; set; }
        [Required]
        public DateTime CrashDate { get; set; }

        [MaxLength(300)]
        public string CrashDescription { get; set; }

        [ForeignKey("Race_ID")]
        public Race Race { get; set; }

        public Person Person { get; set; }
    }
}
