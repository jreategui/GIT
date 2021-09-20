using System;
using System.Collections.Generic;

namespace CargaFicherosApp.Compras
{
    public partial class Dwh
    {
        public int Dwhid { get; set; }
        public string YearMonth { get; set; }
        public string Supplier { get; set; }
        public string Loli { get; set; }
        public string TypeC { get; set; }
        public string Contractnumber { get; set; }
        public string Contractfrom { get; set; }
        public string ContractTo { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Bestbid { get; set; }
        public decimal? Savings { get; set; }
        public decimal? Performance { get; set; }
        public decimal? SavingsPer { get; set; }
        public decimal? PerformancePer { get; set; }
        public string Empresa { get; set; }
        public decimal? OrderValue { get; set; }

    }
}
