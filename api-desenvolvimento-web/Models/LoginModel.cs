using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.Models
{
    public class LoginModel
    {
        [Required]
        public string? NomeUsuario { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}
