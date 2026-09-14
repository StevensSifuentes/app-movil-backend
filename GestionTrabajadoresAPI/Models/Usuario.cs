namespace GestionTrabajadoresAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string? ImagenUsuario { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
    }
}
