using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class Item
    {
        public string shipmentIdKey { get; set; }
        public string shipmentId { get; set; }
        public string orderRelease { get; set; }
        public List<Driver> drivers { get; set; }
        public string powerUnit { get; set; }
        public string licensePlate { get; set; }
        public DateTime scheduledDeparture { get; set; }
        public List<Stop> stops { get; set; }
        public string itinerary { get; set; }
    }
}
