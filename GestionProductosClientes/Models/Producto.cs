using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder {1} caracteres.")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Range(0, 100000, ErrorMessage = "El precio debe estar entre {1} y {2}.")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La existencia debe ser un número entero >= 0.")]
        [Display(Name = "Existencia")]
        public int Existencia { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una marca válida.")]
        [Display(Name = "Id Marca")]
        public int IdMarca { get; set; }
    }
}

