using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    [Table("ULKE")]
    public class Country : MyProjectEntity
    {
        public string UlkeAd { get; set; }

        [Column("UlkeId")]
        [Key]
        public   int Id { get; set; }
    }
    public class vahap 
    {
        public int v { get; set; }
    }
}
