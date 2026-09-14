using System.ComponentModel.DataAnnotations;

namespace GestionTrabajadoresAPI.DTOs
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "El Nombre de Usuario es requerido.")]
        [StringLength(50, ErrorMessage = "El Nombre de Usuario no debe exceder los 50 caracteres.")]
        public string NombreUsuario { get; set; } = null!;

        public string? ImagenUsuario { get; set; }

        [Required(ErrorMessage = "El Email es requerido.")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido.")]
        [StringLength(50, ErrorMessage = "El Email no debe exceder los 50 caracteres.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La Contraseña es requerida.")]
        [MinLength(8, ErrorMessage = "La Contraseña debe tener al menos 8 caracteres.")]
        public string Contrasenia { get; set; } = null!;
    }
}
