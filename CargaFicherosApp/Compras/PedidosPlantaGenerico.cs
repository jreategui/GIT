using System;
using System.Collections.Generic;

namespace CargaFicherosApp.Compras
{
    public partial class PedidosPlantaGenerico
    {
        public string GProveedor { get; set; }
        public string GUp { get; set; }
        public string GClave { get; set; }
        public string GPedido { get; set; }
        public DateTime? GFechaInicio { get; set; }
        public DateTime? GFechaFin { get; set; }
        public DateTime? GFechaConfirmacion { get; set; }
        public string GStatus { get; set; }
        public string GMoneda { get; set; }
        public string GImporte { get; set; }
        public string PProveedor { get; set; }
        public DateTime? PFechaInicio { get; set; }
        public DateTime? PFechaFin { get; set; }
        public DateTime? PFechaConfirmacion { get; set; }
        public string PStatus { get; set; }
        public string PMoneda { get; set; }
        public string PImporte { get; set; }
    }
}
