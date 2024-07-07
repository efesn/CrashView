using CrashView.Entities;
using System.ComponentModel.DataAnnotations;

namespace CrashView.Dto.Response
{
    public class CrashResponseDto
    {
            public int Crash_ID { get; set; }
            public int Race_ID { get; set; }
            public int Person_ID { get; set; }
            public DateTime CrashDate { get; set; }
            public string CrashDescription { get; set; }
    }
}
