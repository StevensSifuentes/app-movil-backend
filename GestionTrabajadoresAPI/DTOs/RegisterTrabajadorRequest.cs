using System.ComponentModel.DataAnnotations;

namespace GestionTrabajadoresAPI.DTOs
{
    public class RegisterTrabajadorRequest
    {
        [Required(ErrorMessage = "El Usuario es requerido.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El Nombre no debe exceder los 50 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El Apellido no debe exceder los 50 caracteres.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El DNI es requerido.")]
        [StringLength(8, ErrorMessage = "El DNI no debe exceder los 8 caracteres.")]
        public string Dni { get; set; } = null!;

        [Required(ErrorMessage = "La Edad es requerida.")]
        [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100 años.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El Género es requerido.")]
        public string Genero { get; set; } = null!;

        [StringLength(100, ErrorMessage = "El Cargo no debe exceder los 100 caracteres.")]
        public string? Cargo { get; set; }
    }
}
