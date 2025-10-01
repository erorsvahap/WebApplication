using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEntities
{
    public class Country : BaseEntity
    {
        public Country() { }

        [DbIdentity]
        [DbColumnName("UlkeId")]
        public int Id { get; set; }  // Identity kolon ve kolon imi sql deki gerçek ismi tut
        public override string TableName => "ULKE";

        public string UlkeAd { get; set; }


    }
}
