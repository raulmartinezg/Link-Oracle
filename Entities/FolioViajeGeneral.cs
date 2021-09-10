using System;
using System.Collections.Generic;

#nullable disable

namespace LinkOracle.Entities
{
    public partial class FolioViajeGeneral
    {
        
        public string ClaveFolioViaje { get; set; }
        public string FolioViaje { get; set; }
        public string Operador { get; set; }
        public string Unidad { get; set; }
        public string Placa { get; set; }
        public string Ruta { get; set; }
        public DateTime SalidaProgramada { get; set; }
    }
}
