using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vizsga_ASP_NET.Models
{
    [Table("example")]
    public class Example
    {
        public int Id{ get; set; }

        [Required]
        public string Name{ get; set; }
    }
}
