using CrashView.Entities;
using System.ComponentModel.DataAnnotations;

namespace CrashView.Dto.Request
{
    public class PersonsResponseDto
    {
        public int Person_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int Role_ID { get; set; }
        public int Team_ID { get; set; }

        //public Role Role { get; set; }
        //public Team Team { get; set; }
    }
}

