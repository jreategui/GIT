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
    public class KiraExcel<TEntity> : ExcelHelper<TEntity>
    where TEntity : KiraModel
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
                var result = new KiraModel
                {
                    DM=Convert.ToString(reader.GetValue(0)),
                    accountRessource=Convert.ToString(reader.GetValue(1)),
                    vwgPreferredUserAccount=Convert.ToString(reader.GetValue(2))
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