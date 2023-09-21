using Projeto.Business.Models;

namespace api_desenvolvimento_web.DTO
{
    public class CriarAtendimentoDTO
    {
        public DateTime Data { get; set; }
        public string NumeroCarteira { get; set; }
        public double? PesoPaciente { get; set; }
        public double? AlturaPaciente { get; set; }
        public bool Aberto { get; set; }
        public DateTime? DataFim { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
