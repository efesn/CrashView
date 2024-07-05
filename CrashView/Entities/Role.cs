using System.ComponentModel.DataAnnotations;

namespace CrashView.Entities
{
    public class Role
    {
        [Key]
        public int Role_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role_Name { get; set; }
    }
}
