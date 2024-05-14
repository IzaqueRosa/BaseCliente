using BaseCliente.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseCliente.Data.DataBase
{
    public class BaseClienteContext : DbContext
    {
        public BaseClienteContext(DbContextOptions<BaseClienteContext> options) : base(options)
        {
        }
        public DbSet<Banco> Banco { get; set;}
        public DbSet<Cliente> Cliente { get; set; }
    }
}
