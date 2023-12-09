public class ProductosServicio
{
    private readonly ApplicationDbContext _context;

    public Productos(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Producto> ObtenerProductoPorIdAsync(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task AgregarProductoAsync(Producto nuevoProducto)
    {
        _context.Productos.Add(nuevoProducto);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarProductoAsync(Producto productoActualizado)
    {
        _context.Productos.Update(productoActualizado);
        await _context.SaveChangesAsync();
    }
}
