using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class Master
    {
        public List<TbmaeViaje> Viaje { get; set; }
        public List<TbmaeStop> Stop { get; set; }
        public List<FolioViajeGeneral> Folios { get; set; }
    }
}
