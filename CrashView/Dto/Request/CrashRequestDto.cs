using System.ComponentModel.DataAnnotations;

namespace CrashView.Dto.Request
{
    public class CrashRequestDto
    {
        public int Crash_ID { get; set; }
        public int Race_ID { get; set; }
        public int Person_ID { get; set; }
        public DateTime CrashDate { get; set; }
        public string CrashDescription { get; set; }
        public string Impact { get; set; }
        public byte[] Crash_Video { get; set; }
    }
}
