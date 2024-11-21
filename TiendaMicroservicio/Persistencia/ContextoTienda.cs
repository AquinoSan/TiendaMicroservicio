using Microsoft.EntityFrameworkCore;
using TiendaMicroservicio.Models;

namespace TiendaMicroservicio.Persistencia
{
    public class ContextoTienda : DbContext
    {
        public ContextoTienda(DbContextOptions<ContextoTienda> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
