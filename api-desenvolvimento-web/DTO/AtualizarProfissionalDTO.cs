using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class AtualizarProfissionalDTO
    {
        [Required]
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? NumeroConselho { get; set; }
        public string? UFConselho { get; set; }
        public string? Especialidade { get; set; }
    }
}
