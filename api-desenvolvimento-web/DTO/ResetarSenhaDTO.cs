using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class ResetarSenhaDTO
    {
        [Required(ErrorMessage = "Nome de usuario é obrigatório!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Senha antiga é obrigatório!")]
        public string SenhaAntiga { get; set; }

        [Required(ErrorMessage = "Nova senha é obrigatório!")]
        public string NovaSenha { get; set; }
    }
}
