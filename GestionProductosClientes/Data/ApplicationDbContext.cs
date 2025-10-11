using Microsoft.EntityFrameworkCore;
using GestionProductosClientes.Models;

namespace GestionProductosClientes.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Marca> Marca { get; set; } = null!;
        #endregion

        #region Configuración del Modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tabla Productos
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Proteína Whey", Descripcion = "Sabor vainilla 1kg", Precio = 899.99m, Existencia = 12, IdMarca = 1 },
                new Producto { Id = 2, Nombre = "Mancuerna 5kg", Descripcion = "Par de mancuernas recubiertas", Precio = 599.50m, Existencia = 8, IdMarca = 2 },
                new Producto { Id = 3, Nombre = "Bandas Elásticas", Descripcion = "Set 3 niveles", Precio = 199.00m, Existencia = 25, IdMarca = 3 },
                new Producto { Id = 4, Nombre = "Colchoneta Yoga", Descripcion = "Antideslizante 6mm", Precio = 249.90m, Existencia = 30, IdMarca = 4 },
                new Producto { Id = 5, Nombre = "Guantes de gym", Descripcion = "Talla M", Precio = 149.00m, Existencia = 20, IdMarca = 5 }
            );
            #endregion


            #region tabla Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "Luis", ApellidoPaterno = "García", ApellidoMaterno = "Lopez", Telefono = "5512345678" },
                new Cliente { Id = 2, Nombre = "María", ApellidoPaterno = "Pérez", ApellidoMaterno = "Sánchez", Telefono = "5523456789" },
                new Cliente { Id = 3, Nombre = "Carlos", ApellidoPaterno = "Ramírez", ApellidoMaterno = "Diaz", Telefono = "5534567890" },
                new Cliente { Id = 4, Nombre = "Ana", ApellidoPaterno = "Martínez", ApellidoMaterno = "Ortiz", Telefono = "5545678901" },
                new Cliente { Id = 5, Nombre = "Jorge", ApellidoPaterno = "Hernández", ApellidoMaterno = "Ruiz", Telefono = "5556789012" }
            );
            #endregion

            #region
            modelBuilder.Entity<Marca>().HasData(
              new Marca { IdMarca = 1, NombreM = "Nike" },
              new Marca { IdMarca = 2, NombreM = "Adidas" },
              new Marca { IdMarca = 3, NombreM = "Puma" },
              new Marca { IdMarca = 4, NombreM = "Reebok" },
              new Marca { IdMarca = 5, NombreM = "Under Armour" }
            );

            #endregion
        }
        #endregion
    }
}
