using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Required, StringLength(50)]
        public string ApellidoPaterno { get; set; } = null!;

        [StringLength(50)]
        public string? ApellidoMaterno { get; set; }

        [Phone]
        public string? Telefono { get; set; }
    }
}
