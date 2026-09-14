using GestionTrabajadoresAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTrabajadoresAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.NombreUsuario).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Email).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Contrasenia).HasMaxLength(255).IsRequired();
                entity.Property(u => u.ImagenUsuario).HasMaxLength(255);

                entity.HasIndex(u => u.NombreUsuario).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.ToTable("Trabajadores");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nombre).HasMaxLength(50).IsRequired();
                entity.Property(t => t.Apellido).HasMaxLength(50).IsRequired();
                entity.Property(t => t.Dni).HasMaxLength(8).IsRequired();
                entity.Property(t => t.Genero).HasMaxLength(10).IsRequired();
                entity.Property(t => t.Cargo).HasMaxLength(100);

                entity.HasIndex(t => t.Dni).IsUnique();

                entity.HasOne(t => t.Usuario)
                    .WithMany()
                    .HasForeignKey(t => t.UsuarioId);
            });
        }
    }
}
