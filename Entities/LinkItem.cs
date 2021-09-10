using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class LinkItem
    {
        public string orderReleaseId { get; set; }
        public string shipmentId { get; set; }
        public string zone { get; set; }
        public string inItinerary { get; set; }
    }
}
