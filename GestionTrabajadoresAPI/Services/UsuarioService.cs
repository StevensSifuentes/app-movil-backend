using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Data.Repository.IRepository;
using GestionTrabajadoresAPI.Services.IServices;

namespace GestionTrabajadoresAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IJwtService _jwtService;

        public UsuarioService(IUsuarioRepository repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<bool> Registrar(RegisterRequest request)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(request.Contrasenia);
            var exito = await _repository.Crear(request.NombreUsuario, request.Email, hash, request.ImagenUsuario);

            return exito;
        }

        public async Task<LoginResponse?> Login(LoginRequest request)
        {
            var usuario = await _repository.ObtenerParaLogin(request.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Contrasenia, usuario.Contrasenia)) return null;

            var token = _jwtService.GenerarToken(usuario);

            return new LoginResponse
            {
                Token = token,
                Usuario = new RegisterResponse
                {
                    Id = usuario.Id,
                    NombreUsuario = usuario.NombreUsuario,
                    ImagenUsuario = usuario.ImagenUsuario,
                    Email = usuario.Email
                }
            };
        }
    }
}
