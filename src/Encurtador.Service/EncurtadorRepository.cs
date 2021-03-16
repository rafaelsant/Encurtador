using System.Linq;
using System.Threading.Tasks;
using Encurtador.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Service
{
    public class EncurtadorRepository : IEncurtadorRepository
    {
        private readonly Context context;
        public EncurtadorRepository(Context context)
        {
            this.context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<EncurtadorEntity> GetAsyncById(int Id)
        {
            IQueryable<EncurtadorEntity> query = context.Encurtador;
            query = query
                   .AsNoTracking().Where(c => c.Id == Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<EncurtadorEntity> GetByHttpAsync(string http)
        {
            IQueryable<EncurtadorEntity> query = context.Encurtador;
            query = query
                   .AsNoTracking().Where(c => c.LinkEncurt == http);
            return await query.FirstOrDefaultAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }
    }
}