using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CargaFicherosApp.Compras;
using CargaFicherosApp.Data;
using CargaFicherosApp.Models;

namespace CargaFicherosApp.Controllers
{
    public class GBPLController
    {
        private comprasContext comprasContextDB;
        private GBPLRepository gbplRepository;
        public GBPLController()
        {
            comprasContextDB = new Compras.comprasContext();
            this.gbplRepository = new GBPLRepository(comprasContextDB);
        }


        public void ReadAndAddToDatabase(string file)
        {
            using (var reader = new StreamReader(file))
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                //csv.Configuration.RegisterClassMap<FooMap>();

                /*       var record = new GBPLModel();
                       var records = csv.EnumerateRecords(record);
                       System.Console.WriteLine(string.Format("Cantidad de registros {0}", records.Count()));

                       int i=0;*/
                csv.Read();
                csv.ReadHeader();
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                var records = csv.GetRecords<GBPLModel>().ToList();
                System.Console.WriteLine(string.Format("Cantidad de registros {0}", records.Count()));
                int i = 0;
                // KSRM result;
                foreach (var k in records)
                {
                    i++;
                    if (i % 100 == 0)
                    {
                        System.Console.WriteLine(string.Format("van {0} registros", i));
                    }
                    DateTime? nullDateTime = null;
                    var result = gbplRepository.GetOrdersByCOSIALTA(DateTime.ParseExact(k.COSIALTA, "yyyy-MM-dd-HH.mm.ss.ffffff", System.Globalization.CultureInfo.InvariantCulture));
                    if (result == null)
                    {
                        gbplRepository.Crear(new Compras.Gbpl
                        {
                            Cliefnr = k.CLIEFNR,
                            Cobestnr = k.COBESTNR,
                            Cocausal = k.COCAUSAL,
                            Coclavw0 = k.COCLAVW0,
                            Codcuota = k.CODCUOTA,
                            Codresto = string.IsNullOrWhiteSpace(k.CODRESTO.Trim()) ? nullDateTime : DateTime.ParseExact(k.CODRESTO, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Codunsnr = k.CODUNSNR,
                            Comoneda = k.COMONEDA,
                            Comonese = k.COMONESE,
                            Compania = k.COMPANIA,
                            Coorige = k.COORIGE,
                            Costatus = k.COSTATUS,
                            Cosialta = DateTime.ParseExact(k.COSIALTA, "yyyy-MM-dd-HH.mm.ss.ffffff", CultureInfo.InvariantCulture),
                            Cotipnum = k.COTIPNUM,
                            Counmevw = k.COUNMEVW,
                            Coupseat = k.COUPSEAT,
                            Counprvw = k.COUNPRVW,
                            Cowerkvw = k.COWERKVW,
                            Feconped = string.IsNullOrWhiteSpace(k.FECONPED.Trim()) ? nullDateTime : DateTime.ParseExact(k.FECONPED, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Fefinhis = string.IsNullOrWhiteSpace(k.FEFINHIS.Trim()) ? nullDateTime : DateTime.ParseExact(k.FEFINHIS, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Feiniefe = string.IsNullOrWhiteSpace(k.FEINIEFE.Trim()) ? nullDateTime : DateTime.ParseExact(k.FEINIEFE, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Fesimodi = string.IsNullOrWhiteSpace(k.FESIMODI.Trim()) ? nullDateTime : DateTime.ParseExact(k.FESIMODI, "yyyy-MM-dd-HH.mm.ss.ffffff", CultureInfo.InvariantCulture),
                            Feverlst = string.IsNullOrWhiteSpace(k.FEVERLST.Trim()) ? nullDateTime : DateTime.ParseExact(k.FEVERLST, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Feverlwe = string.IsNullOrWhiteSpace(k.FEVERLWE.Trim()) ? nullDateTime : DateTime.ParseExact(k.FEVERLWE, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Pradebon = decimal.Parse(k.PRADEBON, new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            Prbrseeu = decimal.Parse(k.PRBRSEEU, new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            Prbrudiv = decimal.Parse(k.PRBRUDIV, new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            Prbrueur = decimal.Parse(k.PRBRUEUR, new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            Prelogis = k.PRELOGIS,
                            Prunidiv = decimal.Parse(k.PRUNIDIV, new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            Prunieur = decimal.Parse(k.PRUNIEUR, new NumberFormatInfo() { NumberDecimalSeparator = "," }),
                            Prvrsedv = decimal.Parse(k.PRVRSEDV, new NumberFormatInfo() { NumberDecimalSeparator = "," })
                        }
                        );
                    }
                }
            }

        }
    }
}