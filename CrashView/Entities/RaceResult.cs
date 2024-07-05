using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class RaceResult
    {
        [Key]
        public int RaceResult_ID { get; set; }
        [Required]
        public int Race_ID { get; set; }
        public Race Race { get; set; }
        [Required]
        public int Person_ID { get; set; } 
        public Person Person { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public int PointsEarned { get; set; }
    }
}
