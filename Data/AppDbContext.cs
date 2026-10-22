using Microsoft.EntityFrameworkCore;
using FerreteriaValdivia.Models;

namespace FerreteriaValdivia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}