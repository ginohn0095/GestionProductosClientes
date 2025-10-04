using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionProductosClientes.Data;
using GestionProductosClientes.ViewModels;

namespace GestionProductosClientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var vm = clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                ApellidoPaterno = c.ApellidoPaterno,
                ApellidoMaterno = c.ApellidoMaterno,
                Telefono = c.Telefono
            }).ToList();

            return View(vm);
        }
    }
}
