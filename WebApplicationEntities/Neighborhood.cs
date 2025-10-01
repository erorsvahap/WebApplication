using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEntities
{
    public class Neighborhood : BaseEntity
    {
        public override string TableName => "Semt";
        public  int DistrictId { get; set; }
    }
}
