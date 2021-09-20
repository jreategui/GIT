using CargaFicherosApp.Compras;
using System.Linq;
using System.Threading.Tasks;

namespace CargaFicherosApp.Data
{
    public interface IDWHOracleRepository : IGenericRepository<SICG_F_DWH_CONSORCIAL>
    {
        Task<SICG_F_DWH_CONSORCIAL> GetGetAllContractsFromExcel();
        SICG_F_DWH_CONSORCIAL GetAllContractByNumberAndDate(string contractNumber, string Period);

        IQueryable<SICG_F_DWH_CONSORCIAL> GetAllContractByNumber(string contractNumber);

        IQueryable<SICG_F_DWH_CONSORCIAL> GetAllConsorcialDocumentsByPeriod(string period);



    }
}
