using Microsoft.EntityFrameworkCore;
using Entidades;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Producto> CatalogoProductos { get; set; }
}
