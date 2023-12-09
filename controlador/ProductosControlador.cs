using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entidades;

[Route("api/[controller]")]
public class ProductosController : Controller
{
    private readonly ProductosServicio _productos_servicio;

    public ProductosController(ProductosServicio productos_servicio)
    {
        _productos_servicio = productos_servicio;
    }

    [HttpGet]
    public async Task<IEnumerable<Producto>> VerProductos()
    {
        return await _productos_servicio.ObtenerProductosAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> VerProducto(int id)
    {
        var producto = await _productos_servicio.ObtenerProductoPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    /* [HttpGet]
    public IActionResult AgregarProducto()
    {
        return View();
    } */

    [HttpPost]
    public async Task<IActionResult> AgregarProducto(Producto nuevoProducto)
    {
        if (ModelState.IsValid)
        {
            await _productos_servicio.AgregarProductoAsync(nuevoProducto);
            return RedirectToAction("Index"); // Redirige a la página principal u otra página
        }

        return View(nuevoProducto);
    }

    [HttpPut]
    public async Task<IActionResult> EditarProducto(int id)
    {
        var producto = await _productos_servicio.ObtenerProductoPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    /* [HttpPost]
    public async Task<IActionResult> EditarProducto(Producto productoActualizado)
    {
        if (ModelState.IsValid)
        {
            await _productos_servicio.ActualizarProductoAsync(productoActualizado);
            return RedirectToAction("Index"); // Redirige a la página principal u otra página
        }

        return View(productoActualizado);
    } */
}
