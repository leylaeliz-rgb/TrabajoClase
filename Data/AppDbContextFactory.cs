using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BackofficeApi.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Server=127.0.0.1;Port=3306;Database=tu_base_datos;Uid=root;Pwd=Username4590747;";

            // SOLUCIÓN: Definir una versión estática (por ejemplo, MySQL 8.0 o 9.0)
            // Esto evita que EF Core intente conectarse a la red durante el diseño
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

            optionsBuilder.UseMySql(connectionString, serverVersion);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
