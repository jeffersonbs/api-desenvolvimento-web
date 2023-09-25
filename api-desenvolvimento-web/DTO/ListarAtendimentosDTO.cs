using Projeto.Business.Models;

namespace api_desenvolvimento_web.DTO
{
    public class ListarAtendimentosDTO
    {
        public List<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();
        public int NumeroPaginas { get; set; }
        public int PaginaAtual { get; set; }
    }
}
