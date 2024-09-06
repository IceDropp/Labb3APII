using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3API.Models
{
    public class PersonInterest
    {
        [Key]
        public int PersonInterestId { get; set; }
        [ForeignKey("Persons")]
        public int FkPersonId { get; set; }
        public Person? Persons { get; set; }

        [ForeignKey("Interests")]
        public int FkInterestId { get; set; }
        
        public Interest? Interests { get; set; }

    }
}
