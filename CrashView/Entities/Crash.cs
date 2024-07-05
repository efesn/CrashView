using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Crash
    {
        [Key]
        public int Crash_ID { get; set; }
        [Required]
        public int Race_ID { get; set; }
        [Required]
        public int Person_ID { get; set; }
        [Required]
        public DateTime CrashDate { get; set; }

        [MaxLength(300)]
        public string CrashDescription { get; set; }
        public Race Race { get; set; }
        public Person Person { get; set; }
    }
}
