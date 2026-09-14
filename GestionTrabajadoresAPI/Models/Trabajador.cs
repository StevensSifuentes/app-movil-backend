using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionTrabajadoresAPI.Models
{
    public class Trabajador
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Dni { get; set; } = null!;

        public int Edad { get; set; }

        public string Genero { get; set; } = null!;

        public string? Cargo { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore] // se excluye del JSON de salida
        public Usuario? Usuario { get; set; }
    }
}
