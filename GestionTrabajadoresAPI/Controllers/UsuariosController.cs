using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GestionTrabajadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost()]
        public async Task<IActionResult> Registrar([FromBody] RegisterRequest usuario)
        {
            try
            {
                var exito = await _usuarioService.Registrar(usuario);
                if (!exito) return BadRequest(new { message = "No se pudo crear al Usuario." });
                return CreatedAtAction(nameof(Registrar), new { status = "OK", message = "Usuario creado correctamente." });
            }
            catch (SqlException ex) when (ex.Message.Contains("ya está"))
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var resultado = await _usuarioService.Login(request);

            if (resultado == null) return Unauthorized(new { message = "Usuario o contraseña incorrecta." });

            return Ok(resultado);
        }

    }
}
