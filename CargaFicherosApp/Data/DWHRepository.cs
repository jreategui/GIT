using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CargaFicherosApp.Compras;
using System;

namespace CargaFicherosApp.Data
{
    public class DWHRepository : GenericRepository<Dwh>, IDWHRepository
    {

        public DWHRepository(Compras.comprasContext dbContext)
        : base(dbContext)
        {

        }

        public IQueryable<Dwh> GetAllContractByNumber(string contractNumber)
        {
            return GetAll()
               .Where(c => c.Contractnumber == contractNumber )
               .OrderByDescending(c => c.Dwhid);
        }

        public IQueryable<Dwh> GetAllContractByFECHA(string period)
        {
            return GetAll()
               .Where(c => c.YearMonth == period)
               .OrderByDescending(c => c.Dwhid);
        }

        public Dwh GetAllContractByNumberAndDate(string contractNumber, string Period)
        {
            return GetAll()
                .Where(c => c.Contractnumber == contractNumber && c.YearMonth == Period)
                .OrderByDescending(c => c.Dwhid)
                .FirstOrDefault();
        }


        public async Task<Dwh> GetGetAllContractsFromExcel()
        {
            throw new NotImplementedException();
            //return await GetAll()
            //    .OrderByDescending(c => c.)
            //    .FirstOrDefaultAsync();
        }

    }
}
