namespace GestionProductosClientes.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public string PrecioDisplay => Precio.ToString("C");
        public int IdMarca { get; set; }
        public string ? NombreM { get; set; }


    }
}
