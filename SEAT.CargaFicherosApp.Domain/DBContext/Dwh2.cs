using System;
using System.Collections.Generic;

namespace CargaFicherosApp.Compras
{
    public partial class Dwh2
    {
        public int? Dwhid { get; set; }
        public string Empresa { get; set; }
        public int? YearMonth { get; set; }
        public string Supplier { get; set; }
        public string Loli { get; set; }
        public string TypeC { get; set; }
        public long? Contractnumber { get; set; }
        public string Contractfrom { get; set; }
        public string ContractTo { get; set; }
        public double? Budget { get; set; }
        public double? Bestbid { get; set; }
        public double? Savings { get; set; }
        public double? Performance { get; set; }
        public double? SavingsPer { get; set; }
        public double? PerformancePer { get; set; }
    }
}
