using System.Linq;
using System.Threading.Tasks;
using CargaFicherosApp.Compras;

namespace CargaFicherosApp.Data
{
    public interface IKSRMRepository: IGenericRepository<Ksrm>
    {
        Task<Ksrm> GetGetAllContractsFromExcel();
        Ksrm GetAllContractByNumberAndDate(string contractNumber,string Period);

        IQueryable<Ksrm> GetAllContractByNumber(string contractNumber);

        IQueryable<Ksrm> GetAllContractByFECHA(string period);
    }
}