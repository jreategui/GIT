using System;
using DWHLoadApp.DWH;
using Oracle.ManagedDataAccess.Client;





namespace DWHLoadApp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/odpnt/EFCoreSampleCode.html#GUID-71B4A0A3-7B88-4D4D-BC99-8ACB2F344280
             */
            using (var db = new DWHContext())
            {
                var blog = new SICG_F_DWH_CONSORCIAL { BESTBID= 22,
                    ORDERNUMBER = "222222",
                    YEARMONTH="111111"
                    };
                db.SICG_F_DWH_CONSORCIAL.Add(blog);
                db.SaveChanges();
            }
            using (var db = new DWHContext())
            {
                var blogs = db.SICG_F_DWH_CONSORCIAL;
            }




            string ConnString = "USER ID = USER_COMPRAS;Password=Pa_cnntrsvcok21!; DATA SOURCE = 10.82.4.248:1523 / DTWHSEAT;";// PERSIST SECURITY INFO = True
            using (OracleConnection con = new OracleConnection(ConnString))
            {
                using (OracleCommand cmd =con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;
                        cmd.CommandText="select * from SICG.SICG_F_CGENERALES_KSRM where coingest=:id order by fecha desc";
                        OracleParameter id = new OracleParameter("id","C16");
                        cmd.Parameters.Add(id);
                        OracleDataReader Oreader = cmd.ExecuteReader();
                        while (Oreader.Read()) 
                        {
                            Console.WriteLine("NUPEDIDO: "+Oreader.GetString(0));
                        }
                        Oreader.Dispose();

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }
    }
}
