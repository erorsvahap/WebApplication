using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    [Table("Ilce")]
    public class District : MyProjectEntity
    {
        [Key]
        [Column("IlceId")]
        public override int Id { get; set; }
        public int IlId { get; set; }
        public string IlceAd { get; set; }
    }
}
