using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEntities
{
    public class City : BaseEntity
    {
        public override string TableName => "Il";
        public int UlkeId { get; set; }

        [DbIdentity]
        [DbColumnName("IlId")]
        public int Id { get; set; }
        public string IlAd { get; set; }

    }
}
