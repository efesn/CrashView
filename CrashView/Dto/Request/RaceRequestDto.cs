namespace CrashView.Dto.Request
{
    public class RaceRequestDto
    {
        public string Race_Name { get; set; }
        public int Season_ID { get; set; }
        public int Track_ID { get; set; }
        public DateTime Race_Date { get; set; }
        public string Season_Name { get; set; }
        public string Track_Name { get; set; }
    }
}
