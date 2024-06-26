using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.RotaDaReciclagem.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}