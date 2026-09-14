using GestionTrabajadoresAPI.Data.Repository.IRepository;
using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Models;
using GestionTrabajadoresAPI.Services.IServices;
using Microsoft.Data.SqlClient;

namespace GestionTrabajadoresAPI.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly ITrabajadorRepository _repository;

        public TrabajadorService(ITrabajadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Crear(RegisterTrabajadorRequest trabajador)
        {
            try
            {
                var exito = await _repository.Crear(trabajador);
                return exito;
            }
            catch (SqlException ex) when (ex.Message.Contains("ya está"))
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Trabajador>> Listar(int usuarioId)
        {
            var trabajadores = await _repository.Listar(usuarioId);
            return trabajadores.ToList();
        }
    }
}
