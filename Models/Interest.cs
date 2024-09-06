using System.ComponentModel.DataAnnotations;

namespace Labb3API.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 

    }
}
