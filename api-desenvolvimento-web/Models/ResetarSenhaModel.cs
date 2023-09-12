using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.Models
{
    public class ResetarSenhaModel
    {
        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string SenhaAntiga { get; set; }

        [Required]
        public string NovaSenha { get; set; }
    }
}
