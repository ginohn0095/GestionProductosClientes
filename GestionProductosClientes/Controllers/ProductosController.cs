using GestionProductosClientes.Data;
using GestionProductosClientes.Models;
using GestionProductosClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductosClientes.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Muestra lista de productos
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.AsNoTracking().ToListAsync();
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

        //GET: búsqueda por ID con AJAX
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
                return Json(new { success = false, message = "Ocurrió un error al buscar el producto.", error = ex.Message });
            }
        }

        //POST: crear producto con AJAX
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errores = ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .Select(e => new
                        {
                            Campo = e.Key,
                            Mensajes = e.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                        });

                    return Json(new { success = false, message = "Error de validación.", errors = errores });
                }

                // Crear Producto
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
                        producto.Existencia
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error al crear el producto.", error = ex.Message });
            }
        }
    }
}
