using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Entities
{
    public class Guia
    {
        public int Id { get; set; }
        public int NoGuia { get; set; }
        public string Dealer { get; set; }
        public string Codigo { get; set; }
        public int Escaneados { get; set; }
        public DateTime Ingreso { get; set; }
        public int Cantidad { get; set; }
    }
}
