using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }


        [Required, StringLength(50)]
        public string ? NombreM { get; set; }
    }
}
