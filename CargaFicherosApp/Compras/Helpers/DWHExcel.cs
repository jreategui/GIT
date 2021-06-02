using CargaFicherosApp.Helpers;
using CargaFicherosApp.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CargaFicherosApp.Compras.Helpers
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class DWHExcel<TEntity> : ExcelHelper<TEntity>
    where TEntity : DWHModel
    {
        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        public override TEntity AddingNewElement(IExcelDataReader reader, string Period)
        {
            try
            {
                if (Convert.ToString(reader.GetValue(1)) == "Monat")
                {
                    return null;
                }
                var result = new DWHModel
                {
                    Year = Convert.ToString(reader.GetValue(0)),
                    Month = Convert.ToInt32(reader.GetValue(1)).ToString("00"),//Convert.ToString(reader.GetValue(1)),
                    Company = Convert.ToString(reader.GetValue(2)),
                    Provider = Convert.ToString(reader.GetValue(3)),
                    LOLI = Convert.ToString(reader.GetValue(4)),
                    Type = Convert.ToString(reader.GetValue(5)),
                    ContractNumber = Convert.ToString(reader.GetValue(6)),
                    FromDate = Convert.ToString(reader.GetValue(7)),
                    ToDate = Convert.ToString(reader.GetValue(8)),
                    Budget = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(9))) ? "0" : Convert.ToString(reader.GetValue(9))),
                    Bestellwert = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(10))) ? "0" : Convert.ToString(reader.GetValue(10))),
                    BestBid = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(11)).Replace("--", "0")) ? "0" : Convert.ToString(reader.GetValue(11)).Replace("--", "0")),
                    Savings = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(12)).Replace("--", "0")) ? "0" : Convert.ToString(reader.GetValue(12)).Replace("--", "0")),
                    Performance = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(13)).Replace("--", "0")) ? "0" : Convert.ToString(reader.GetValue(13)).Replace("--", "0")),
                    SavingsPer = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(14)).Replace("--", "0")) ? "0" : Convert.ToString(reader.GetValue(14)).Replace("--", "0")),
                    PerformancePer = Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(reader.GetValue(15)).Replace("--", "0")) ? "0" : Convert.ToString(reader.GetValue(15)).Replace("--", "0"))
                };
                return (TEntity)Convert.ChangeType(result, typeof(TEntity));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception Adding Element. Exception Message:{0}. Key{1}.", ex.Message, Convert.ToString(reader.GetValue(6))));
            }
            return null;
        }

    }

}