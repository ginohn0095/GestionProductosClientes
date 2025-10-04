using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionProductosClientes.Data;
using GestionProductosClientes.ViewModels;

namespace GestionProductosClientes.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();
            var vm = productos.Select(p => new ProductoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Existencia = p.Existencia
            }).ToList();

            return View(vm);
        }
    }
}
