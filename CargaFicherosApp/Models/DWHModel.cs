namespace CargaFicherosApp.Models
{
    public class DWHModel
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Company { get; set; }
        public string Provider { get; set; }
        public string LOLI { get; set; }
        public string Type { get; set; }
        public string ContractNumber { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public decimal Budget { get; set; }
        public decimal Bestellwert { get; set; }
        public decimal BestBid { get; set; }
        public decimal Savings { get; set; }
        public decimal Performance { get; set; }
        public decimal SavingsPer { get; set; }
        public decimal PerformancePer { get; set; }
        public string Period { get { return string.Format("{0}{1}",Year ,Month);  }  }
        public decimal? OrderValue { get; set; }

    }
}
