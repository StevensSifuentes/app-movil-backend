using GestionTrabajadoresAPI.Data.Repository.IRepository;
using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionTrabajadoresAPI.Data.Repository
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly ApplicationDbContext _db;

        public TrabajadorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Crear(RegisterTrabajadorRequest trabajador)
        {
            var filasAfectadas = await _db.Database.ExecuteSqlRawAsync(
                "EXEC usp_CrearTrabajador @UsuarioId, @Nombre, @Apellido, @Dni, @Edad, @Genero, @Cargo",
                new SqlParameter("@UsuarioId", trabajador.UsuarioId),
                new SqlParameter("@Nombre", trabajador.Nombre),
                new SqlParameter("@Apellido", trabajador.Apellido),
                new SqlParameter("@Dni", trabajador.Dni),
                new SqlParameter("@Edad", trabajador.Edad),
                new SqlParameter("@Genero", trabajador.Genero),
                new SqlParameter("@Cargo", (object?)trabajador.Cargo ?? DBNull.Value)
            );

            return filasAfectadas > 0;
        }

        public async Task<List<Trabajador>> Listar(int usuarioId)
        {
            return await _db.Trabajadores
                    .FromSqlRaw(
                        "EXEC usp_ListarTrabajadores @UsuarioId",
                        new SqlParameter("@UsuarioId", usuarioId)
                    )
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
