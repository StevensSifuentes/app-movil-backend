using GestionTrabajadoresAPI.DTOs;

namespace GestionTrabajadoresAPI.Services.IServices
{
    public interface IUsuarioService
    {
        Task<bool> Registrar(RegisterRequest request);
        Task<LoginResponse?> Login(LoginRequest request);
    }
}
