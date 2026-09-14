using GestionTrabajadoresAPI.Models;

namespace GestionTrabajadoresAPI.Data.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerParaLogin(string email);
        Task<bool> Crear(string nombreUsuario, string email, string contraseniaHash, string? imagenUsuario = null);
    }
}
