// Ejemplo en un controlador ASP.NET MVC
public class ProductoController : Controller
{
    private readonly ProductosServicio _mi_servicio;

    public ProductoControlador(ProductosServicio productos_servicio)
    {
        _mi_servicio = productos_servicio;
    }

    public async Task<IActionResult> VerProducto(int id)
    {
        var producto = await _mi_servicio.ObtenerProductoPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpGet]
    public IActionResult AgregarProducto()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AgregarProducto(Producto nuevoProducto)
    {
        if (ModelState.IsValid)
        {
            await _mi_servicio.AgregarProductoAsync(nuevoProducto);
            return RedirectToAction("Index"); // Redirige a la página principal u otra página
        }

        return View(nuevoProducto);
    }

    [HttpGet]
    public async Task<IActionResult> EditarProducto(int id)
    {
        var producto = await _mi_servicio.ObtenerProductoPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> EditarProducto(Producto productoActualizado)
    {
        if (ModelState.IsValid)
        {
            await _mi_servicio.ActualizarProductoAsync(productoActualizado);
            return RedirectToAction("Index"); // Redirige a la página principal u otra página
        }

        return View(productoActualizado);
    }
}
