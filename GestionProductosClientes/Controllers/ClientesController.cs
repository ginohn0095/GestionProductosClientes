using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionProductosClientes.Data;
using GestionProductosClientes.ViewModels;
using GestionProductosClientes.Models;

namespace GestionProductosClientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
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

        // POST: crear cliente vía AJAX
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
                    Telefono = model.Telefono
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
            catch (DbUpdateException dbEx)
            {
                return Json(new { success = false, message = "Error al guardar en la base de datos.", detail = dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error inesperado.", detail = ex.Message });
            }
        }
    }
}
