using GestionTrabajadoresAPI.Data.Repository.IRepository;
using GestionTrabajadoresAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionTrabajadoresAPI.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Usuario?> ObtenerParaLogin(string email)
        {
            var resultado = await _db.Usuarios
                .FromSqlInterpolated($"EXEC usp_ObtenerUsuarioParaLogin {email}")
                .AsNoTracking()
                .ToListAsync();

            return resultado.FirstOrDefault();
        }

        public async Task<bool> Crear(string nombreUsuario, string email, string contraseniaHash, string? imagenUsuario = null)
        {
            var filasAfectadas = await _db.Database.ExecuteSqlRawAsync(
                "EXEC usp_CrearUsuario @NombreUsuario, @Email, @ContraseniaHash, @ImagenUsuario",
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Email", email),
                new SqlParameter("@ContraseniaHash", contraseniaHash),
                new SqlParameter("@ImagenUsuario", (object?)imagenUsuario ?? DBNull.Value)
            );
            return filasAfectadas > 0;
        }
    }
}
