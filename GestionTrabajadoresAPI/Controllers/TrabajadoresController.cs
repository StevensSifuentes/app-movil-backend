using GestionTrabajadoresAPI.DTOs;
using GestionTrabajadoresAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace GestionTrabajadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // requiere JWT válido
    public class TrabajadoresController : ControllerBase
    {
        private readonly ITrabajadorService _service;

        public TrabajadoresController(ITrabajadorService service)
        {
            _service = service;
        }

        // Obtener el id del usuario autenticado
        private int ObtenerUsuarioId() =>
        int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpPost()]
        public async Task<IActionResult> Crear([FromBody] RegisterTrabajadorRequest trabajador)
        {
            trabajador.UsuarioId = ObtenerUsuarioId();

            try
            {
                var exito = await _service.Crear(trabajador);
                if (!exito) return BadRequest(new { message = "No se pudo crear al Trabajador." });
                return CreatedAtAction(nameof(Listar), new { status = "OK", message = "Trabajador creado correctamente.", trabajador });
            }
            catch (SqlException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Listar()
        {
            var usuarioId = ObtenerUsuarioId();
            var trabajadores = await _service.Listar(usuarioId);
            return Ok(trabajadores);
        }
    }
}
