using System.Linq;
using System.Threading.Tasks;
using CargaFicherosApp.Compras;

namespace CargaFicherosApp.Data
{
    public interface IKSRMExtensionRepository: IGenericRepository<KsrmExtension>
                     
    {
        Task<KsrmExtension> GetGetAllContractsFromExcel();
        KsrmExtension GetAllContractByNumberAndDate(string contractNumber,string Period);
        IQueryable<KsrmExtension> GetAllContractByNumber(string contractNumber);
    }
}