using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrashView.Entities
{
    public class Person
    {
        [Key]
        public int Person_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Last_Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }

        public int Role_ID { get; set; }
        
        [ForeignKey("Role_ID")]
        public Role Role { get; set; }

        public int? Team_ID { get; set; }
        
        [ForeignKey("Team_ID")]
        public Team Team { get; set; }
    }
}
