using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Track
    {
        [Key]
        public int Track_ID { get; set; }
        public string Track_Name { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Number_Of_Laps { get; set; }
        public string Fastest_Lap_Record { get; set; }

        public decimal? Track_Length_km { get; set; }

        public decimal? Total_Race_Length_km { get; set; }

        public int? Audience_Capacity { get; set; }
    }
}
