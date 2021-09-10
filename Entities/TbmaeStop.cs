using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class TbmaeStop
    {
        public int ClaveStop { get; set; }
        public int? ClaveViaje { get; set; }
        public int? ShipUnitId { get; set; }
        public string  Zone { get; set; }
        public string OrderRelease { get; set; }
        public bool EnRuta { get; set; }
    }
}
