using ExcelDataReader;
using System.IO;
using System.Collections.Generic;
using System;

namespace CargaFicherosApp.Helpers
{
    public class ExcelHelper<TEntity>
    {
    
        public List<TEntity> GetListFromExcelFile(string file, string tapName, string period){
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var registros = new List<TEntity>(); 
            using (var stream = System.IO.File.Open(@file, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        reader.NextResult()  ; 
                        if (reader.Name!=tapName)
                        {
                            throw new System.Exception("No esta bien posicionada la pestaña plantilla");
                        }
                        while (reader.Read()) //Each row of the file
                        {
                            var  result=AddingNewElement(reader,period);
                            if (result!=null)
                                registros.Add(result);
                        }
                    }
                }
           
                return registros;
        }

        public virtual TEntity AddingNewElement(IExcelDataReader reader,string Period)
        {
            throw new NotImplementedException();
        }
    }
}