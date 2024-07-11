using System.ComponentModel.DataAnnotations.Schema;

namespace CrashView.Dto.Request
{
    public class PersonTeamHistoryDto
    {
        public int PersonTeamHistory_ID { get; set; }
        public int Person_ID { get; set; }
        public string Person_Name { get; set; }
        public int Team_ID { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? EmploymentStatus { get; set; }
    }
}
