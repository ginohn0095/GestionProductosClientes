using System.ComponentModel.DataAnnotations;

namespace GestionProductosClientes.ViewModels
{
    public class MarcaViewModel
    {
        public int IdMarca { get; set; }


        [Required, StringLength(50)]
        public string? NombreM { get; set; }
    }
}
