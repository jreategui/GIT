using System;
using System.Linq;
using System.Collections.Generic;
using CargaFicherosApp.Models;
using CargaFicherosApp.Controllers;
using CargaFicherosApp.Helpers;
using System.IO;
using CsvHelper;
using System.Globalization;
using CargaFicherosApp.Compras.Helpers;

namespace CargaFicherosApp
{
    class Program
    {
        private string folder = @"\\seesmtswqaopf\163\Groups\10-SUP\Compras\Informe_Eficiencias\Generación\";

        static void Main(string[] args)
        {
            KSRMController KController;

            GBPLController gBPLController;
            Console.WriteLine("Por favor indicar el periodo a cargar/analizar: (YYYYMM)");
            //  var periodo = Console.ReadLine();


            KSRMExcel<KsrmModel> KExcel = new KSRMExcel<KsrmModel>();
            List<KsrmModel> Lista = new List<KsrmModel>();
            KController = new KSRMController();
            /* gBPLController = new GBPLController();
             gBPLController.ReadAndAddToDatabase(@"D:\zip delete\ZIPEA\hp_pro.joma.zipea.txt");*/
            //gBPLController.ReadAndAddToDatabase(@"D:\zip delete\ZIPEA\temp.csv");//

            var salida = "";
            while (salida.ToUpper() != "X")
            {
             salida= MenuOptions();
            }

            //Console.WriteLine("Por favor indicar la carpeta para buscar los ficheros");
            //var path = @"\\seesmtswqaopf\163\Groups\10-SUP\Compras\Informe_Eficiencias\Generación\202011";

            //Console.ReadLine();
            ////var period = path.Split("\\")[path.Split("\\").Length-1];
            //var period = path.Split("\\")[^1];

            //ReadDWHExcelFile(path, period);

            //KController.LoadKSRMExcelToDB(@"D:\USUARIS\siwrmu5\Desktop\4 Valores de carga de CMS-KSRM April_2020sobran.xlsx", "Plantilla","202004");

        }


        private static string MenuOptions()
        {
            var confirm = "N";
            var period = "";
            var option = "";
            var path = @"\\seesmtswqaopf\163\Groups\10-SUP\Compras\Informe_Eficiencias\Generación\";
            var VALID = "";
            while (confirm.ToUpper() == "N")
            {
                Console.WriteLine("Indique el periodo:");
                period = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Seleccione que quiere hacer:");
                Console.WriteLine("");
                Console.WriteLine("[1] Cargar DWH");
                Console.WriteLine("[2] Cargar K-SRM");
                Console.WriteLine("[3] Cargar K-SRM Extensiones");
                Console.WriteLine("[4] prueba");
                Console.WriteLine("[5] Crear sistema de ficheros");
                Console.WriteLine("[6] Obtener listado de Contratos Extensión");
                Console.WriteLine("[X] SALIR");
                option = Console.ReadLine();
                Console.WriteLine("Usted ha seleccionado [{0}]. es correcto? Y/N", option);
                confirm = Console.ReadLine();
                Console.Clear();
            }

            var salida = "";


            switch (option)
            {
                case "1":
                    VALID = ValidateOrProcess();
                    ReadDWHExcelFile(path, period, VALID);
                    break;
                case "2":
                    VALID = ValidateOrProcess();
                    ReadKSRMExcelFile(path, period, VALID);
                    break;
                case "3":
                    VALID = ValidateOrProcess();
                    ReadKSRMExtensionExcelFile(path, period, VALID);
                    break;
                case "4":
                    ReadOtherExcelFile(path, period, VALID);
                    break;
                case "5":
                    CreateSystemFile(period,string.Format("{0}{1}", path, "XXXXXX"), string.Format("{0}{1}", path, period), true);
                    break;
                case "6":
                    GetContractExtensionList(path, period, VALID);
                    break;
                case "X":
                    salida = "X";
                    break;
            }
            Console.WriteLine("Presione cualquier tecla para continuar....");
            Console.ReadKey();
            Console.Clear();
            return salida;
        }

        private static void GetContractExtensionList(string path, string period, string vALID)
        {
            KSRMController kController;
            List<KsrmModel> Lista = new List<KsrmModel>();
            kController = new KSRMController();
            Lista = kController.GetKSRMByFECHA( period);
            foreach(var K in Lista)
            {
                Console.WriteLine(K.NUPEDIDO);
            }

            Console.WriteLine("");
            Console.WriteLine("presionar Enter despúes de copiar");
            Console.ReadLine(); 





        }

        private static string ValidateOrProcess()
        {
            string VALID = "";
            while (VALID.ToUpper() != "V" && VALID.ToUpper() != "I")
            {
                Console.WriteLine("Seleccione que desea hacer:");
                Console.WriteLine("[V] Solo Validar");
                Console.WriteLine("[I] Insertar ");
                VALID = Console.ReadLine();
                Console.Clear();
            }
            return VALID;
        }

        private static void CreateSystemFile(string period, string sourceDirName, string destDirName, bool copySubDirs)
        {
               
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name.Replace("XXXXXX",period));
                file.CopyTo(tempPath, false);
                Console.WriteLine("Copiando {0}", tempPath);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    Console.WriteLine("Creando Subdir {0}", subdir.Name);
                    string tempPath = Path.Combine(destDirName, subdir.Name.Replace("XXXXXX",period));
                    CreateSystemFile(period,subdir.FullName, tempPath, copySubDirs);

                }
            }
        
    }

        private static void ReadOtherExcelFile(string path, string period, string vALID)
        {
            KiraExcel<KiraModel> KExcel = new KiraExcel<KiraModel>();
            List<KiraModel> Lista = new List<KiraModel>();
            string file = @"D:\USUARIS\siwrmu5\OneDrive - Volkswagen AG\Compras\Apps\K-SRM\Acceso PKI\Problemas Acceso PKI\KIRA_resources_ksrm_limitado.xls";
            Lista = KExcel.GetListFromExcelFile(file, "Export", period).Select(x => (KiraModel)Convert.ChangeType(x, typeof(KiraModel))).ToList();

            foreach( var k in Lista)
             {
                var Nombrea = k.DM.Split(',').DefaultIfEmpty("Unknown").FirstOrDefault().ToString();
                if (Nombrea != "dn") {
                    Nombrea = Nombrea.Remove(0, 4);
                    Nombrea = Nombrea.Remove(Nombrea.Length - 17, 17);
                    var AcountResource = k.accountRessource.Split('|').Where(s => s.Contains("PR_KSP100")).ToList();
                    var Prefered = k.vwgPreferredUserAccount;
                    var KsrmPreferent = AcountResource.Where(s => s.Contains(Prefered)).ToList();
                    if (AcountResource.Count > 1)
                    {
                        Console.WriteLine("{1}; con 2 usuarios en K-SRM ; {0}", Prefered, Nombrea);
                    }

                    if (KsrmPreferent.Count == 0)
                    {
                        Console.WriteLine("{2};K-SRM Distinto al PREFERED; {0}; {1}", Prefered, AcountResource.DefaultIfEmpty("Unknown").FirstOrDefault().ToString(), Nombrea);
                    }
                    string ee = "";
                }
            }
        }

        private static void ReadKSRMExcelFile(string path, string period, string valid)
        {
            KSRMController kController;
            KSRMExcel<KsrmModel> KExcel = new KSRMExcel<KsrmModel>();
            List<KsrmModel> Lista = new List<KsrmModel>();
            kController = new KSRMController();
            kController.LoadKSRMExcelToDB(string.Format(@"{0}\{1}\RPA\{1}_KSRM.xlsx", path, period), "Plantilla", period, valid);
        }

        private static void ReadKSRMExtensionExcelFile(string path, string period, string valid)
        {
            KSRMController kController;
            KSRMExcel<KsrmModel> KExcel = new KSRMExcel<KsrmModel>();
            List<KsrmModel> Lista = new List<KsrmModel>();
            kController = new KSRMController();
            kController.LoadKSRMExtensionExcelToDB(string.Format(@"{0}\{1}\RPA\{1}_KSRM_Extensiones.xlsx", path, period), "Plantilla", period, valid);

        }

        private static void ReadDWHExcelFile(string path, string period, string valid)
        {
            DWHController dController;
            DWHExcel<DWHModel> KExcel = new DWHExcel<DWHModel>();
            List<DWHModel> ListaInsert = new List<DWHModel>();
            dController = new DWHController();
            ListaInsert = dController.LoadDWHExcelToDB(string.Format("{0}\\{1}\\QlikView\\{1}_procesado.xlsx", path, period), "Document_CH_Detailtable", period, valid);
            KSRMController kController=new KSRMController();
            foreach (var k in ListaInsert)
            {
                Console.WriteLine("************************************************************");
                Console.WriteLine("Original Contrato : {0}. Periodo: {1}.   Budget Excel: {2}.  BestBid:{3}", k.ContractNumber, k.Period, k.Budget, k.BestBid);
                var DWHList = dController.GetKDWHByNumber(k.ContractNumber);
                foreach (var DM in DWHList)
                {
                    Console.WriteLine("Esta DWH Contrato : {0}. Periodo: {1}.   Budget Excel: {2}.  BestBid:{3}", DM.Contractnumber, DM.YearMonth, DM.Budget, DM.Bestbid);
                    
                }
                var KSRMList = kController.GetKSRMByNumber(k.ContractNumber);
                foreach (var Ksrm in KSRMList)
                {
                    Console.WriteLine("K-SRM    Contrato : {0}. Periodo: {1}.   Budget Excel: {2}.  BestBid:{3}", Ksrm.Nupedido, Ksrm.Fecha, Ksrm.Importe, Ksrm.Importebestbid);
                }
                var KSRMEList = kController.GetKSRMExtensionByNumber(k.ContractNumber);
                foreach (var Ksrme in KSRMEList)
                {
                    Console.WriteLine("K-SRMExt Contrato : {0}. Periodo: {1}.   Budget Excel: {2}.  BestBid:{3}", Ksrme.Nupedido, Ksrme.Fecha, Ksrme.Importe, Ksrme.Importebestbid);
                }


            }


        }
    }
}


//dotnet ef dbcontext scaffold "server=labz440av;port=3306;user=compras_usr;password=Santiago001;database=compras" MySql.Data.EntityFrameworkCore -o Compras -f