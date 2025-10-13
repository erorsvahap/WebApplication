using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    [Table("Il")]
    public class City : MyProjectEntity
    {

        public string IlAd { get; set; }
        [Column("IlId")]
        [Key]
        public override int Id { get; set; }
        public int UlkeId { get; set; }



    }
}
