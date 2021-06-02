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
    public class KSRMController
    {
        private IKSRMRepository ksrmRepository;
        private IDWHRepository DWHRepository;
        private IKSRMExtensionRepository ksrmExtensionRepository;
        private Compras.comprasContext comprasContextDB;

        public KSRMController()
        {
            comprasContextDB = new Compras.comprasContext();
            this.ksrmRepository = new KSRMRepository(comprasContextDB);
            this.DWHRepository = new DWHRepository(comprasContextDB);
            this.ksrmExtensionRepository = new KSRMExtensionRepository(comprasContextDB);

        }
        public List<Ksrm>  GetKSRMByNumber(string contractNumber) 
        {
            
            return ksrmRepository.GetAllContractByNumber(contractNumber).ToList();
        }

        public List<KsrmExtension> GetKSRMExtensionByNumber(string contractNumber)
        {
            return ksrmExtensionRepository.GetAllContractByNumber(contractNumber).ToList();
        }


        public List<KsrmModel> GetKSRMByFECHA(string Period)
        {
            var result = new List<KsrmModel>();
            var ksrmList = ksrmRepository.GetAllContractByFECHA(Period).ToList();
            var dwhList = DWHRepository.GetAllContractByFECHA(Period).ToList();
            foreach (var DW in dwhList)
            {
                if (!ksrmList.Exists(x => x.Nupedido== DW.Contractnumber))
                {
                    result.Add(
                        new KsrmModel {
                            NUPEDIDO=DW.Contractnumber
                        }
                        );
                }
            }
            return result;
        }


        public void LoadKSRMExcelToDB(string file, string tab, string period, string valid)
        {
            KSRMExcel<KsrmModel> KExcel = new KSRMExcel<KsrmModel>();
            List<KsrmModel> Lista = new List<KsrmModel>();
            List<KsrmModel> ListaExiste = new List<KsrmModel>();
            Lista = KExcel.GetListFromExcelFile(file, tab, period).Select(x => (KsrmModel)Convert.ChangeType(x, typeof(KsrmModel))).ToList();
            // KSRM result;
            foreach (KsrmModel k in Lista)
            {

                var result = ksrmRepository.GetAllContractByNumberAndDate(k.NUPEDIDO, k.FECHA);
                if (result == null)
                {
                    if (valid.ToUpper() == "I")
                    {
                        ksrmRepository.Crear(new Compras.Ksrm
                        {
                            Fecha = k.FECHA,
                            Nupedido = k.NUPEDIDO,
                            Version = k.VERSION,
                            Codbuyer = k.CODBUYER,
                            Nusolcom = k.NUSOLCOM,
                            Cosocdad = ValidateCodSocdad(k.COSOCDAD),
                            Coprovee = k.COPROVEE,
                            Coingest = k.COINGEST,
                            FechaEmision = k.FECHA_EMISION,
                            Importe = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTE) ? "0" : k.IMPORTE),
                            Importesc = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTESC) ? "0" : k.IMPORTESC),
                            Importebestbid = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTEBESTBID) ? "0" : k.IMPORTEBESTBID),
                            Divisa = k.DIVISA,
                            Cambio = decimal.Parse(k.CAMBIO),
                            Delincom = k.DELINCOM,
                            GrupoCompra = k.Grupo_compra,
                        });
                    }
                    else
                    {
                        Console.WriteLine("Insert: Contrato : {0}. Periodo: {1}. Budget Excel: {2}.", k.NUPEDIDO, k.FECHA, k.IMPORTE);
                    }
                }
                else
                {
                    ListaExiste.Add(k);
                    Console.WriteLine("Existe: Contrato : {0}. Periodo: {1}. Budget Excel: {2}. Budget DB: {3}.", k.NUPEDIDO, k.FECHA, k.IMPORTE, result.Importe);
                }
            }
        }

        public void LoadKSRMExtensionExcelToDB(string file, string tab, string period, string valid)
        {
            KSRMExcel<KsrmModel> KExcel = new KSRMExcel<KsrmModel>();
            List<KsrmModel> Lista = new List<KsrmModel>();
            List<KsrmModel> ListaExiste = new List<KsrmModel>();
            Lista = KExcel.GetListFromExcelFile(file, tab, period).Select(x => (KsrmModel)Convert.ChangeType(x, typeof(KsrmModel))).ToList();
            // KSRM result;
            foreach (KsrmModel k in Lista)
            {

                var result = ksrmExtensionRepository.GetAllContractByNumberAndDate(k.NUPEDIDO, k.FECHA);
                if (result == null)
                {
                    if (valid.ToUpper() == "I")
                    {
                        ksrmExtensionRepository.Crear(new Compras.KsrmExtension
                        {
                            Fecha = k.FECHA,
                            Nupedido = k.NUPEDIDO,
                            Version = k.VERSION,
                            Codbuyer = k.CODBUYER,
                            Nusolcom = k.NUSOLCOM,
                            Cosocdad = ValidateCodSocdad(k.COSOCDAD),
                            Coprovee = k.COPROVEE,
                            Coingest = k.COINGEST,
                            FechaEmision = k.FECHA_EMISION,
                            Importe = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTE) ? "0" : k.IMPORTE),
                            Importesc = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTESC) ? "0" : k.IMPORTESC),
                            Importebestbid = Convert.ToDecimal(string.IsNullOrEmpty(k.IMPORTEBESTBID) ? "0" : k.IMPORTEBESTBID),
                            Divisa = k.DIVISA,
                            Cambio = decimal.Parse(k.CAMBIO),
                            Delincom = k.DELINCOM,
                            GrupoCompra = k.Grupo_compra,
                        });
                    }
                    else
                    {
                        Console.WriteLine("Insert: Contrato : {0}. Periodo: {1}. Budget Excel: {2}.", k.NUPEDIDO, k.FECHA, k.IMPORTE);
                    }
                }
                else
                {
                    ListaExiste.Add(k);
                    Console.WriteLine("Extensión Existe: Contrato : {0}. Periodo: {1}. Budget Excel: {2}. Budget DB: {3}.", k.NUPEDIDO, k.FECHA, k.IMPORTE, result.Importe);
                }
            }
        }

        private string ValidateCodSocdad(string cOSOCDAD)
        {
            var result = cOSOCDAD;
           if (string.IsNullOrEmpty(cOSOCDAD))
            {
                result = "VWN1";
            }
            return result;
        }
    }
}