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
    public class AtualizarAtendimentoDTO
    {
        [Required]
        public int? Id { get; set; }
        public DateTime? Data { get; set; }
        public string? NumeroCarteira { get; set; }
        public double? PesoPaciente { get; set; }
        public double? AlturaPaciente { get; set; }
        public bool? Aberto { get; set; }
        public DateTime? DataFim { get; set; }
        public int? PacienteId { get; set; }
        public int? ProfissionalId { get; set; }
    }
}
