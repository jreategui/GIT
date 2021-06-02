using System;
using System.Diagnostics;
using CargaFicherosApp.Models;
using ExcelDataReader;

namespace CargaFicherosApp.Helpers
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class KSRMExcel <TEntity> : ExcelHelper<TEntity>
    where TEntity : KsrmModel
    {
       private string GetDebuggerDisplay()
        {
            return ToString();
        }

        public override TEntity AddingNewElement(IExcelDataReader reader,string Period)
        {
            try{
                if (Convert.ToString(reader.GetValue(1))=="VERSION")
                {
                    return null;
                }
                var result= new KsrmModel
                {
                        FECHA=Period,
                        NUPEDIDO = Convert.ToString(reader.GetValue(0)),
                        VERSION = Convert.ToString(reader.GetValue(1)),
                        CODBUYER = Convert.ToString(reader.GetValue(2)),
                        NUSOLCOM = Convert.ToString(reader.GetValue(3)),
                        COSOCDAD = Convert.ToString(reader.GetValue(4)),
                        COPROVEE = Convert.ToString(reader.GetValue(5)),
                        COINGEST = Convert.ToString(reader.GetValue(6)),
                        FECHA_EMISION = Convert.ToString(reader.GetValue(7)),
                        IMPORTE = Convert.ToString(reader.GetValue(8)),
                        IMPORTESC = Convert.ToString(reader.GetValue(9)),
                        IMPORTEBESTBID = Convert.ToString(reader.GetValue(10)),
                        DIVISA = Convert.ToString(reader.GetValue(11)),
                        CAMBIO = Convert.ToString(reader.GetValue(12)),
                        DELINCOM = Convert.ToString(reader.GetValue(13)),
                        Grupo_compra = Convert.ToString(reader.GetValue(14))

                };
                 return (TEntity) Convert.ChangeType(result, typeof(TEntity));
                                }
                catch (Exception ex)
                {
                    Console.Write(string.Format("Exception Adding Element. Exception Message:{0}. Key{1}.",ex.Message,Convert.ToString(reader.GetValue(0))));
                }
                return null;
        }
       
    }

}