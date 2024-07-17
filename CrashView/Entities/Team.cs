using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Team
    {
        [Key]
        public int Team_ID { get; set; }
        public string Team_Name { get; set; }
        public string Base_Country { get; set; }
    }
}
