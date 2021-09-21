using System;
using System.Linq;
using System.Collections.Generic;
using CargaFicherosApp.Models;
using CargaFicherosApp.Controllers;
using CargaFicherosApp.Helpers;
using CargaFicherosApp.Data;
using CargaFicherosApp.Compras.Helpers;
using CargaFicherosApp.Compras;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace CargaFicherosApp.Controllers
{
    public class DWHOracleController
    {


        private IDWHOracleRepository _DWHOracleRepository;
        private DWHContext DWHContextDB;
        public DWHOracleController()
        {
            DWHContextDB = new DWHContext();
            _DWHOracleRepository = new DWHOracleRepository(DWHContextDB);
        }
        public List<Dwh> GetAllKDWHByPeriod(string Period)
        {

            var Lista = _DWHOracleRepository.GetAllConsorcialDocumentsByPeriod(Period).ToList();

            return null;
        }

        public List<DWHModel> LoadDWHExcelToDB(string file, string tab, string period, string valid)
        {
            DWHExcel<DWHModel> DExcel = new DWHExcel<DWHModel>();
            List<DWHModel> Lista = new List<DWHModel>();
            List<DWHModel> ListaExiste = new List<DWHModel>();
            List<DWHModel> ListaInsert = new List<DWHModel>();

            Lista = DExcel.GetListFromExcelFile(file, tab, period).Where(x => x.Period == period).ToList();
            
            //.Select(x => (DWHModel)Convert.ChangeType(x, typeof(DWHModel))).ToList();

            
            var duplicates = Lista.GroupBy(a => a).SelectMany(ab => ab.Skip(1).Take(1)).ToList();

            // KSRM result;
            foreach (DWHModel k in Lista)
            {

                var result = _DWHOracleRepository.GetAllContractByNumberAndDate(k.Period, k.ContractNumber);
                if (result == null)
                {
                    if (valid.ToUpper() == "I")
                    {
                        _DWHOracleRepository.Crear(new SICG_F_DWH_CONSORCIAL
                        {
                            YEARMONTH = k.Period,
                            SUPPLIER = k.Provider,
                            LOLI = k.LOLI,
                            DOCTYPE = k.Type,
                            ORDERNUMBER= k.ContractNumber,
                            CONTRACTFROM = k.FromDate,
                            CONTRACTTO = k.ToDate,
                            BUDGET = k.Budget,
                            BESTBID = k.BestBid,
                            SAVINGS = k.Savings,
                            PERFORMANCE = k.Performance,
                            COMPANY = k.Company,
                            PERFORMANCE_PER = k.PerformancePer,
                            SAVINGS_PER = k.SavingsPer,
                            ORDERVALUE= (decimal)k.Bestellwert
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
                    Console.WriteLine("Existe: Contrato : [{4}] - {0}. Periodo: {1}. Budget Excel: {2}. Budget DB: {3}.", k.ContractNumber, k.Period, k.Budget, result.BUDGET, k.Budget - result.BUDGET);
                }
            }
            return ListaInsert;
            // foreach (DWHModel D in Lista Existe)
        }

        private void AddNewDWH(DWHModel k)
        {
        }
    }
}
