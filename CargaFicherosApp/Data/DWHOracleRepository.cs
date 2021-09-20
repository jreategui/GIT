using System.Linq;
using System.Threading.Tasks;
using CargaFicherosApp.Compras;
using System;

namespace CargaFicherosApp.Data
{
    public class DWHOracleRepository : GenericRepository<SICG_F_DWH_CONSORCIAL>, IDWHOracleRepository
    {

        public DWHOracleRepository(DWHContext dbContext)
        : base(dbContext)
        {

        }

        public IQueryable<SICG_F_DWH_CONSORCIAL> GetAllContractByNumber(string contractNumber)
        {
            return GetAll()
               .Where(c => c.ORDERNUMBER == contractNumber )
               .OrderByDescending(c => c.ORDERNUMBER);
        }

        public IQueryable<SICG_F_DWH_CONSORCIAL> GetAllConsorcialDocumentsByPeriod(string period)
        {
            return GetAll()
               .Where(c => c.YEARMONTH == period)
               .OrderByDescending(c => c.ORDERNUMBER);
        }

        public SICG_F_DWH_CONSORCIAL GetAllConsorcialDocumentsByPeriod(string contractNumber, string Period)
        {
            return GetAll()
                .Where(c => c.ORDERNUMBER == contractNumber && c.YEARMONTH== Period)
                .OrderByDescending(c => c.ORDERNUMBER)
                .FirstOrDefault();
        }


        public async Task<SICG_F_DWH_CONSORCIAL> GetGetAllContractsFromExcel()
        {
            throw new NotImplementedException();
            //return await GetAll()
            //    .OrderByDescending(c => c.)
            //    .FirstOrDefaultAsync();
        }

        Task<SICG_F_DWH_CONSORCIAL> IDWHOracleRepository.GetGetAllContractsFromExcel()
        {
            throw new NotImplementedException();
        }



       

        SICG_F_DWH_CONSORCIAL IDWHOracleRepository.GetAllContractByNumberAndDate(string contractNumber, string Period)
        {
            throw new NotImplementedException();
        }

        IQueryable<SICG_F_DWH_CONSORCIAL> IDWHOracleRepository.GetAllContractByNumber(string contractNumber)
        {
            throw new NotImplementedException();
        }
    }
}
