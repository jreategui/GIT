using System;
using System.Threading.Tasks;
using CargaFicherosApp.Compras;
namespace CargaFicherosApp.Data
{
    public interface IGBPLRepository:  IGenericRepository<Gbpl>
    {
        Task<Gbpl> GetGetAllContractsFromExcel();

        Gbpl GetOrdersByCOSIALTA(DateTime COSIALTA);
    }
}