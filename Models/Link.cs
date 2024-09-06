using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string Url { get; set; }

        [ForeignKey("Interests")]
        public int FkInterestId { get; set; }
        public Interest? Interests { get; set; }
    }
}
