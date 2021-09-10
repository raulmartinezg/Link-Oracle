using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class LinkRoot
    {
        public List<LinkItem> items { get; set; }
        public LinkResult result { get; set; }
    }
}
