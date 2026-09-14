namespace GestionTrabajadoresAPI.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public RegisterResponse Usuario { get; set; } = null!;
    }
}
