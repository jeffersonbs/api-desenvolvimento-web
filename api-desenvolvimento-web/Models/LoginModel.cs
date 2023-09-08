using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nome de usuario é obrigatório!")]
        public string? NomeUsuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório!")]
        public string? Senha { get; set; }
    }
}
