using CargaFicherosApp.Compras;
using System.Linq;
using System.Threading.Tasks;

namespace CargaFicherosApp.Data
{
    public interface IDWHRepository : IGenericRepository<Dwh>
    {
        Task<Dwh> GetGetAllContractsFromExcel();
        Dwh GetAllContractByNumberAndDate(string contractNumber, string Period);

      IQueryable<Dwh> GetAllContractByNumber(string contractNumber);

      IQueryable<Dwh> GetAllContractByFECHA(string period);
    }
}
