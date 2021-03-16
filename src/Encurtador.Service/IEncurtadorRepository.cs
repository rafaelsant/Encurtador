using System.Threading.Tasks;
using Encurtador.Service.Model;
namespace Encurtador.Service
{
    public interface IEncurtadorRepository
    {
        public Task<bool> SaveChangesAsync();
        Task<EncurtadorEntity> GetByHttpAsync(string http);
        Task<EncurtadorEntity> GetAsyncById(int Id);
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}