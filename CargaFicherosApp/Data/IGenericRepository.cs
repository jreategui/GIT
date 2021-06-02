using System.Linq;
using System.Threading.Tasks;

namespace  CargaFicherosApp.Data
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);
        void Crear(TEntity entity);
        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}

