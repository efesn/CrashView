using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Season
    {
        [Key]
        public int Season_ID { get; set; }
        public string Season_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
    }
}
