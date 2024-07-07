using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrashView.Entities
{
    public class RaceResult
    {
        [Key]
        public int RaceResult_ID { get; set; }
        [Required]

        [Column("Race_ID")]
        public int Race_ID { get; set; }

        [ForeignKey("Race_ID")]
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
