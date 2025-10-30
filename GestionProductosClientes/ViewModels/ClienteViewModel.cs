namespace GestionProductosClientes.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasenia { get; set; }
    }
}

