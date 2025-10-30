using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El Id es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Id válido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "La contraseña debe tener entre 3 y 15 caracteres.")]
        public string Contrasenia { get; set; } = null!;
    }
}
