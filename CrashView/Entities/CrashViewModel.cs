using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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

        [Required]
        public int Role_ID { get; set; }

        public int? Team_ID { get; set; }

        [ForeignKey("Role_ID")]
        public Role Role { get; set; }

        [ForeignKey("Team_ID")]
        public Team Team { get; set; }
    }

    public class Role
    {
        [Key]
        public int Role_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role_Name { get; set; }

        public ICollection<Person> Persons { get; set; } = new List<Person>();
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

        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
