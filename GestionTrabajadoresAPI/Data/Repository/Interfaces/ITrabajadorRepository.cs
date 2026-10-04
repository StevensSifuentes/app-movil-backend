using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Models;

namespace GestionTrabajadoresAPI.Data.Repository.IRepository
{
    public interface ITrabajadorRepository
    {
        Task<bool> Crear(RegisterTrabajadorRequest trabajador);
        Task<List<Trabajador>> Listar(int usuarioId);
    }
}
