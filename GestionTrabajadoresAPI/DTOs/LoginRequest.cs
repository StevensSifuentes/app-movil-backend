using System.ComponentModel.DataAnnotations;

namespace GestionTrabajadoresAPI.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El Email es requerido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La Contraseña es requerida.")]
        public string Contrasenia { get; set; } = null!;
    }
}
