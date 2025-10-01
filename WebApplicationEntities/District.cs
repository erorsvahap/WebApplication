using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEntities
{
    public class District : BaseEntity
    {
        public override string TableName => "Ilce";
        public int IlId { get; set; }
        public string IlceAd { get; set; }

        [DbIdentity]
        [DbColumnName("IlceId")]
        public int Id { get; set; }
    }
}
