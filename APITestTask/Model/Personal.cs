using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APITestTask.Model
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        public string Address { get; set; }

        public DateTime DateOpen { get; set; }

        public DateTime DateClose { get; set; }

        public int CountResidents { get; set; }       
    }
    
}
