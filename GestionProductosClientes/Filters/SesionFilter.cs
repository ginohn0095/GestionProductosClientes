using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionProductosClientes.Filters
{
    public class FiltroSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("UsuarioLogueado");
            if (string.IsNullOrEmpty(usuario))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
