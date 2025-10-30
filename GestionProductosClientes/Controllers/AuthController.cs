using GestionProductosClientes.Data;
using GestionProductosClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace GestionProductosClientes.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ GET: Mostrar formulario de login con soporte para returnUrl
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl; // ← Se guarda para redirigir después del login
            return View(new LoginViewModel());
        }

        // ✅ POST: Procesar login y redirigir correctamente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == model.Id && c.Contrasenia == model.Contrasenia);

            if (cliente == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas. Intente nuevamente.");
                return View(model);
            }

            // ✅ Guardar variables de sesión
            HttpContext.Session.SetString("UsuarioLogueado", "true");
            HttpContext.Session.SetString("NombreUsuario", $"{cliente.Nombre} {cliente.ApellidoPaterno}");
            HttpContext.Session.SetInt32("IdUsuario", cliente.Id);

            // ✅ Autenticación por cookies con persistencia
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cliente.Nombre),
                new Claim("IdUsuario", cliente.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, "MiCookie");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MiCookie", principal, new AuthenticationProperties
            {
                IsPersistent = true, // ← Mantiene la cookie activa entre peticiones
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // ← Duración de sesión
            });

            // ✅ Redirección inteligente según returnUrl
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        // ✅ GET: Logout con cierre de sesión y autenticación
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("MiCookie");
            return RedirectToAction("Login");
        }
    }
}
