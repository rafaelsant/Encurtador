
using Encurtador.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Service
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<EncurtadorEntity> Encurtador { get; set; }
    }
}