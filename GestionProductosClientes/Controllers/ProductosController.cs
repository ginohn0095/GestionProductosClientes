using GestionProductosClientes.Data;
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

        // Acción principal que muestra todos los productos
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

        //  AJAX: búsqueda por ID
        [HttpGet]
        public async Task<IActionResult> SearchById(int id)
        {
            try
            {
                // Validamos que el ID sea válido
                if (id <= 0)
                    return Json(new { success = false, message = "El Id debe ser un número entero positivo." });

                // LINQ + EF Core → Busca el producto en la base de datos
                var product = await _context.Productos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return Json(new { success = false, message = "Producto no encontrado" });

                // Retornamos JSON con el producto completo
                return Json(new { success = true, product });
            }
            catch (Exception ex)
            {
                // Capturamos errores y devolvemos mensaje genérico
                return Json(new { success = false, message = "Ocurrió un error al buscar el producto.", detail = ex.Message });
            }
        }
    }
}
