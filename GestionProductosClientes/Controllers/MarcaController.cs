using GestionProductosClientes.Data;
using GestionProductosClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductosClientes.Controllers
{
    public class MarcaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MarcaController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var marca = await _context.Productos.ToListAsync();
            var vm = marca.Select(m => new ProductoViewModel
            {
                Id = m.Id,
                Nombre = m.Nombre,
            }).ToList();

            return View(vm);
        }
    }
}
