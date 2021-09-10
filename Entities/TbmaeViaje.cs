using System;
using System.Collections.Generic;

#nullable disable

namespace LinkOracle.Entities
{
    public partial class TbmaeViaje
    {
        
        public int ClaveViaje { get; set; }
        public int? ClaveEstatus { get; set; }
        public int? ClaveFolioViaje { get; set; }
        public int? ClaveRampa { get; set; }
        public int? ClaveUsuario { get; set; }
        public long? EstatusCro { get; set; }
        public DateTime? FechaEstatus { get; set; }
        public string FirmaOperador { get; set; }
        public string FirmaVerificador { get; set; }
        public string FirmaAuditor { get; set; }
        public string FirmaSupervisor { get; set; }
        public string FolioViaje { get; set; }
        public string Host { get; set; }
        public string Operador { get; set; }
        public string Placa { get; set; }
        public string Ruta { get; set; }
        public DateTime? SalidaProgramada { get; set; }
        public int? Unidad { get; set; }
    }
}
