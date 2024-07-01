using System.ComponentModel.DataAnnotations;

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
        public Role Role { get; set; }

        public int? Team_ID { get; set; }  
        public Team Team { get; set; }
    }


    public class Role
    {
        [Key]
        public int Role_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role_Name { get; set; }
    }

    public class Team
    {
        [Key]
        public int Team_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Team_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Base_Country { get; set; }
    }
}
