using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = null!;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Range(0, 100000)]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue)]
        public int Existencia { get; set; }

 
        public int IdMarca { get; set; }
      

    }
}
