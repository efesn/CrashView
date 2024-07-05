using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrashView.Entities
{
    public class PersonTeamHistory
    {
        [Key]
        public int PersonTeamHistory_ID { get; set; }

        public int Person_ID { get; set; }
        public int Team_ID { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        [ForeignKey("Person_ID")]
        public virtual Person Person { get; set; }

        [ForeignKey("Team_ID")]
        public virtual Team Team { get; set; }
    }
}
