using System;
using System.Linq;
using System.Collections.Generic;
using CargaFicherosApp.Models;
using CargaFicherosApp.Controllers;
using CargaFicherosApp.Helpers;
using CargaFicherosApp.Data;
using CargaFicherosApp.Compras.Helpers;
using CargaFicherosApp.Compras;

namespace CargaFicherosApp.Controllers
{
    public class DWHController
    {


        private IDWHRepository DWHRepository;
        private Compras.comprasContext comprasContextDB;

        public DWHController()
        {
            comprasContextDB = new Compras.comprasContext();
            this.DWHRepository = new DWHRepository(comprasContextDB);

        }
        public List<Dwh> GetKDWHByNumber(string contractNumber)
        {
            var Lista= DWHRepository.GetAllContractByNumber(contractNumber).ToList();
            return Lista;
        }


        public List<DWHModel>  LoadDWHExcelToDB(string file, string tab, string period, string valid)
        {
            DWHExcel<DWHModel> DExcel = new DWHExcel<DWHModel>();
            List<DWHModel> Lista = new List<DWHModel>();
            List<DWHModel> ListaExiste = new List<DWHModel>();
            List<DWHModel> ListaInsert= new List<DWHModel>();

            Lista = DExcel.GetListFromExcelFile(file, tab, period).Select(x => (DWHModel)Convert.ChangeType(x, typeof(DWHModel))).ToList();
            var duplicates = Lista.GroupBy(a => a).SelectMany(ab => ab.Skip(1).Take(1)).ToList();

            // KSRM result;
            foreach (DWHModel k in Lista)
            {

                var result = DWHRepository.GetAllContractByNumberAndDate(k.ContractNumber, k.Period);
                if (result == null)
                {
                    if (valid.ToUpper() == "I")
                    {
                        DWHRepository.Crear(new Compras.Dwh
                        {
                            YearMonth = k.Period,
                            Supplier = k.Provider,
                            Loli = k.LOLI,
                            TypeC = k.Type,
                            Contractnumber = k.ContractNumber,
                            Contractfrom = k.FromDate,
                            ContractTo = k.ToDate,
                            Budget = k.Budget,
                            Bestbid = k.BestBid,
                            Savings = k.Savings,
                            Performance = k.Performance,
                            Empresa = k.Company,
                            PerformancePer = k.PerformancePer,
                            SavingsPer = k.SavingsPer
                            // Importe = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTE) ? "0" : k.IMPORTE),

                        });
                        Console.WriteLine("Insertando: Contrato : {0}. Periodo: {1}. Budget Excel: {2}. ", k.ContractNumber, k.Period, k.Budget);
                    }
                    else
                    {
                        ListaInsert.Add(k);
                        Console.WriteLine("Insert: Contrato : {0}. Periodo: {1}. Budget Excel: {2}. ", k.ContractNumber, k.Period, k.Budget);
                    }

                    }
                    else
                {
                    ListaExiste.Add(k);
                    Console.WriteLine("Existe: Contrato : [{4}] - {0}. Periodo: {1}. Budget Excel: {2}. Budget DB: {3}.", k.ContractNumber, k.Period, k.Budget, result.Budget, k.Budget - result.Budget);
                }
            }
            return ListaInsert;
           // foreach (DWHModel D in Lista Existe)
        }

    }
}
