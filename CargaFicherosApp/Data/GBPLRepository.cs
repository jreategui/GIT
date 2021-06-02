using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CargaFicherosApp.Compras;

namespace CargaFicherosApp.Data
{
    public class GBPLRepository : GenericRepository<Gbpl>, IGBPLRepository
    {
        public GBPLRepository(Compras.comprasContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<Gbpl> GetGetAllContractsFromExcel()
        {
            return await GetAll()
                .OrderByDescending(c => c.Cosialta)
                .FirstOrDefaultAsync();
        }


        public Gbpl GetOrdersByCOSIALTA(DateTime COSIALTA)
        {


            var startDateOffset = new DateTimeOffset(COSIALTA);
            var QUERY =  GetAll()
                .Where(c=>c.Cosialta== COSIALTA)
                .OrderByDescending(c => c.Cosialta)
                .FirstOrDefault();

            return QUERY;
        }

        
    }
}