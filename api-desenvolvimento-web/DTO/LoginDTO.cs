using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Nome de usuario é obrigatório!")]
        public string? NomeUsuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório!")]
        public string? Senha { get; set; }
    }
}
