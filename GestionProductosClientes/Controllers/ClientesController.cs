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

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET:Clientes
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

        // POST: Crear cliente con AJAX
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteViewModel model)
        {
            try
            {
                // Validar modelo recibido desde AJAX
                if (!ModelState.IsValid)
                {
                    var errores = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();

                    return Json(new
                    {
                        success = false,
                        message = "Datos inválidos. Verifica la información ingresada.",
                        errors = errores
                    });
                }

                // Crear instancia del modelo base para guardar en BD
                var cliente = new Cliente
                {
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Telefono = model.Telefono
                };

                // Guardar en base de datos
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                // Retornar respuesta JSON exitosa
                return Json(new
                {
                    success = true,
                    message = "Cliente registrado correctamente.",
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
                return Json(new
                {
                    success = false,
                    message = "Error al guardar el cliente en la base de datos.",
                    detail = dbEx.InnerException?.Message ?? dbEx.Message
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Ocurrió un error inesperado.",
                    detail = ex.Message
                });
            }
        }
    }
}
