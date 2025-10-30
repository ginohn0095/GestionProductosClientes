using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido paterno no puede exceder {1} caracteres.")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; } = null!;

        [StringLength(50, ErrorMessage = "El apellido materno no puede exceder {1} caracteres.")]
        [Display(Name = "Apellido Materno")]
        public string? ApellidoMaterno { get; set; }

        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "La contraseña debe tener entre 3 y 15 caracteres.")]
        [Display(Name = "Contraseña")]
        public string? Contrasenia { get; set; } = null!;
    }
}
