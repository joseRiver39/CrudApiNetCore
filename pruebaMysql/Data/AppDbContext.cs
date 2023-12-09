using Microsoft.EntityFrameworkCore;
using pruebaMysql.Models;

namespace pruebaMysql.Data
{
    public class AppDbContext : DbContext

    {
       public AppDbContext(
             DbContextOptions options): base(options) { }

        public DbSet<Produc> Producs { get; set; }

    }
}
