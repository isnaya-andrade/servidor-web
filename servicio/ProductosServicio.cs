using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

public class ProductosServicio
{
    private readonly ApplicationDbContext _context;

    public ProductosServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
    {
        return await _context.CatalogoProductos.ToListAsync();
    }

    public async Task<Producto> ObtenerProductoPorIdAsync(int id)
    {
        return await _context.CatalogoProductos.FindAsync(id);
    }

    public async Task AgregarProductoAsync(Producto nuevoProducto)
    {
        _context.CatalogoProductos.Add(nuevoProducto);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarProductoAsync(Producto productoActualizado)
    {
        _context.CatalogoProductos.Update(productoActualizado);
        await _context.SaveChangesAsync();
    }
}
