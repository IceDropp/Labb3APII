using System.ComponentModel.DataAnnotations;

namespace Labb3API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        

    }
}
