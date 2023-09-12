using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class CriarUsuarioDTO
    {
        [Required(ErrorMessage = "Nome de usuario é obrigatório!")]
        public string NomeUsuario { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório!")]
        public string? Senha { get; set; }
    }
}
