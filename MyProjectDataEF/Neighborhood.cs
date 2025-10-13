using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectDataEF
{
    [Table("Semt")]
    public class Neighborhood :MyProjectEntity
    {
        [Key]
        [Column("SemtId")]
        public override int Id { get => base.Id; set => base.Id = value; }
        public string SemtAd { get; set; }
        public int IlceId { get; set; }

    }
}
