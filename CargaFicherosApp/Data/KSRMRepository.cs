using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CargaFicherosApp.Compras;

namespace CargaFicherosApp.Data
{
    public class KSRMRepository : GenericRepository<Ksrm>, IKSRMRepository
    {
        public KSRMRepository(Compras.comprasContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<Ksrm> GetGetAllContractsFromExcel()
        {
            return await GetAll()
                .OrderByDescending(c => c.Delincom)
                .FirstOrDefaultAsync();
        }


        public Ksrm GetAllContractByNumberAndDate(string contractNumber,string Period)
        {
            return  GetAll()
                .Where(c=>c.Nupedido==contractNumber && c.Fecha==Period)
                .OrderByDescending(c => c.Delincom)
                .FirstOrDefault();
        }

        public IQueryable<Ksrm> GetAllContractByNumber(string contractNumber)
        {
            return GetAll()
               .Where(c => c.Nupedido == contractNumber)
               .OrderByDescending(c => c.Delincom);
        }

        public IQueryable<Ksrm> GetAllContractByFECHA(string period)
        {
            return GetAll()
               .Where(c => c.Fecha == period)
               .OrderByDescending(c => c.Delincom);
        }



        
    }
}