using GestionProductosClientes.Data;
using GestionProductosClientes.Models;
using GestionProductosClientes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductosClientes.Controllers
{
    [Authorize] //Protege todo el controlador con autenticación por cookies
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Productos
        public async Task<IActionResult> Index()
        {
            ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario") ?? "Usuario";

            var productos = await _context.Productos.AsNoTracking().ToListAsync();

            var vm = productos.Select(p => new ProductoViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Existencia = p.Existencia,
                IdMarca = p.IdMarca
            }).ToList();

            return View(vm);
        }

        //GET: AJAX búsqueda por ID
        [HttpGet]
        public async Task<IActionResult> SearchById(int id)
        {

            try
            {
                if (id <= 0)
                    return Json(new { success = false, message = "El Id debe ser un número entero positivo." });

                var product = await _context.Productos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return Json(new { success = false, message = "Producto no encontrado." });

                return Json(new { success = true, data = product });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error al buscar el producto.", detail = ex.Message });
            }
        }

        //POST: Crear producto con AJAX
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto model)
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

                var producto = new Producto
                {
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Precio = model.Precio,
                    Existencia = model.Existencia,
                    IdMarca = model.IdMarca
                };

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Producto creado correctamente.",
                    data = new
                    {
                        producto.Id,
                        producto.Nombre,
                        producto.Descripcion,
                        producto.Precio,
                        producto.Existencia,
                        producto.IdMarca
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