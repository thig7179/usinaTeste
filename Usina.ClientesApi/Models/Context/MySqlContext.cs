using Microsoft.EntityFrameworkCore;

namespace Usina.ClientesApi.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() {}
        public MySqlContext(DbContextOptions <MySqlContext> options) : base(options) {}
        public DbSet<Cliente> Clientes { get; set; }
    }
}
