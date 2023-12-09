using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Entidades;
using Controladores;

namespace servidor_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Producto> ListaDeProductos { get; set; }
        private readonly ProductosServicio _productos_controlador;

        public IndexModel(ILogger<IndexModel> logger, ProductosServicio productos_controlador)
        {
            _logger = logger;
            _productos_controlador = productos_controlador;
        }

        public async Task OnGetAsync()
        {
            var productos = await _productos_controlador.ObtenerProductosAsync();
            ListaDeProductos = productos.ToList(); 
        }

        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
