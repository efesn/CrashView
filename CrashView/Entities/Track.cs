using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Track
    {
        [Key]
        public int Track_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Track_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Continent { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        public int Number_Of_Laps { get; set; }

        [Required]
        public string Fastest_Lap_Record { get; set; }

        public decimal? Track_Length_km { get; set; }

        public decimal? Total_Race_Length_km { get; set; }

        public int? Audience_Capacity { get; set; }
    }
}
