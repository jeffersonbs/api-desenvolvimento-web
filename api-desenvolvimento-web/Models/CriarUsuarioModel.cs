using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.Models
{
    public class CriarUsuarioModel
    {
        [Required]
        public string? NomeUsuario { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}
