using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class Stop
    {
        public int stopNum { get; set; }
        public string zone { get; set; }
        public List<Detail> details { get; set; }
    }
}
