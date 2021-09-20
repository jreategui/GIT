using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DWHLoadApp.DWH
{

    public class SICG_F_DWH_CONSORCIAL
    {
        [Key]
        [Column(Order = 1)]
        public string YEARMONTH { get; set; }
        public string COMPANY { get; set; }
        public string LOLI { get; set; }
        public string SUPPLIER { get; set; }
        public string DOCTYPE { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ORDERNUMBER { get; set; }
        public string CONTRACTFROM { get; set; }
        public string CONTRACTTO { get; set; }
        public decimal BUDGET { get; set; }
        public decimal ORDERVALUE { get; set; }
        public decimal BESTBID { get; set; }
        public decimal SAVINGS { get; set; }
        public decimal PERFORMANCE { get; set; }
        public decimal SAVINGS_PER { get; set; }
        public decimal PERFORMANCE_PER { get; set; }
                     
    }
}
