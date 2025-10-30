using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionProductosClientes.Controllers
{
    [Authorize] // ? Protege esta vista para usuarios autenticados
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario") ?? "Usuario";
            ViewBag.NombreUsuario = nombreUsuario;
            return View();
        }
    }
}
