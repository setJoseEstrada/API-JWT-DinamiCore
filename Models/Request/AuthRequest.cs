using System.ComponentModel.DataAnnotations;

namespace DynamiCore.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string correo { get; set; }
        [Required]
        public string contrasena { get; set; }
    }
}
