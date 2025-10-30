using GestionProductosClientes.Data;
using GestionProductosClientes.Models;
using GestionProductosClientes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductosClientes.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario") ?? "Usuario";

            var clientes = await _context.Clientes.AsNoTracking().ToListAsync();
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

        [HttpGet]
        public async Task<IActionResult> SearchById(int id)
        {
            try
            {
                if (id <= 0)
                    return Json(new { success = false, message = "El Id debe ser un número entero positivo." });

                var cliente = await _context.Clientes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                    return Json(new { success = false, message = "Cliente no encontrado." });

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        cliente.Id,
                        cliente.Nombre,
                        cliente.ApellidoPaterno,
                        cliente.ApellidoMaterno,
                        cliente.Telefono
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al buscar cliente.", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente model)
        {
            try
            {
                if (!TryValidateModel(model))
                {
                    var errores = ModelState
                        .Where(kvp => kvp.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    return Json(new
                    {
                        success = false,
                        message = "Error de validación.",
                        errors = errores
                    });
                }

                var cliente = new Cliente
                {
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Telefono = model.Telefono,
                    Contrasenia = model.Contrasenia
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Cliente creado correctamente.",
                    data = new
                    {
                        cliente.Id,
                        cliente.Nombre,
                        cliente.ApellidoPaterno,
                        cliente.ApellidoMaterno,
                        cliente.Telefono
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error inesperado.", detail = ex.Message });
            }
        }
    }
}
