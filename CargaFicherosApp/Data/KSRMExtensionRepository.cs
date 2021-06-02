


using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CargaFicherosApp.Compras;

namespace CargaFicherosApp.Data
{
    public class KSRMExtensionRepository : GenericRepository<KsrmExtension>, IKSRMExtensionRepository
    {
        public KSRMExtensionRepository(Compras.comprasContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<KsrmExtension> GetGetAllContractsFromExcel()
        {
            return await GetAll()
                .OrderByDescending(c => c.Delincom)
                .FirstOrDefaultAsync();
        }


        public KsrmExtension GetAllContractByNumberAndDate(string contractNumber,string Period)
        {
            return  GetAll()
                .Where(c=>c.Nupedido==contractNumber && c.Fecha==Period)
                .OrderByDescending(c => c.Delincom)
                .FirstOrDefault();
        }

        public IQueryable<KsrmExtension> GetAllContractByNumber(string contractNumber)
        {
            return GetAll()
            .Where(c => c.Nupedido == contractNumber)
            .OrderByDescending(c => c.Delincom);
        }
    }
}