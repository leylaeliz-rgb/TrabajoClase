using BackofficeApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackofficeApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>(e =>
            {
                e.Property(c => c.Nombre).IsRequired().HasMaxLength(80);
                e.Property(c => c.Descripcion).HasMaxLength(200);
                e.HasIndex(c => c.Nombre).IsUnique();

            });
            modelBuilder.Entity<Producto> (e =>
            { 
                e.Property(p=> p.Nombre).IsRequired().HasMaxLength(100);
                e.Property(p => p.Precio).HasPrecision(10, 2);
                e.HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict); // no podemos borrar una categoria que tiene productos
            });
            modelBuilder.Entity<Usuario>(e =>
            {
                e.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
                e.Property(u => u.Email).IsRequired().HasMaxLength(150);
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.PasswordHash).IsRequired().HasMaxLength(225);
                e.Property(u => u.Telefono).HasMaxLength(225);
                e.Property(u => u.Rol).IsRequired().HasMaxLength(30);
            });
        }
    }
}
