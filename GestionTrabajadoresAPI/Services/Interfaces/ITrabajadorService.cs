using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Models;

namespace GestionTrabajadoresAPI.Services.IServices
{
    public interface ITrabajadorService
    {
        Task<bool> Crear(RegisterTrabajadorRequest trabajador);
        Task<List<Trabajador>> Listar(int usuarioId);
    }
}
