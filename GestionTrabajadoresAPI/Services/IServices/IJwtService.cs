using GestionTrabajadoresAPI.Models;

namespace GestionTrabajadoresAPI.Services.IServices
{
    public interface IJwtService
    {
        string GenerarToken(Usuario usuario);
    }
}
