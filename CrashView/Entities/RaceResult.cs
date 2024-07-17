using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrashView.Entities
{
    public class RaceResult
    {
        [Key]
        public int RaceResult_ID { get; set; }
        [Column("Race_ID")]
        public int Race_ID { get; set; }

        [ForeignKey("Race_ID")]
        //public Race Race { get; set; }
        public int Person_ID { get; set; } 
        //public Person Person { get; set; }
        public int Position { get; set; }
        public int PointsEarned { get; set; }
    }
}
