using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


    public class Root
    {
        public List<Item> items { get; set; }
    }


}
