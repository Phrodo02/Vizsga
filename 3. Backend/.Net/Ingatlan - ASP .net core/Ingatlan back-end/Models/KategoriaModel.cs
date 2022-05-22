using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ingatlan_back_end.Models
{
    [Table("kategoriak")]
    public class KategoriaModel
    {
        public int Id { get; set; }
        [Required]
        public string Nev { get; set; }
    }
}
