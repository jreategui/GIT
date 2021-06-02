using System;
using System.Collections.Generic;

namespace CargaFicherosApp.Compras
{
    public partial class KsrmExtension
    {
        public int Idksrm { get; set; }
        public string Fecha { get; set; }
        public string Nupedido { get; set; }
        public string Version { get; set; }
        public string Codbuyer { get; set; }
        public string Nusolcom { get; set; }
        public string Cosocdad { get; set; }
        public string Coprovee { get; set; }
        public string Coingest { get; set; }
        public string FechaEmision { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Importesc { get; set; }
        public decimal? Importebestbid { get; set; }
        public string Divisa { get; set; }
        public decimal? Cambio { get; set; }
        public string Delincom { get; set; }
        public string GrupoCompra { get; set; }
        public string Idstring { get; set; }
    }
}
