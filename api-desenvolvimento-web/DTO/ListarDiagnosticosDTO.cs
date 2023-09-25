using Projeto.Business.Models;

namespace api_desenvolvimento_web.DTO
{
    public class ListarDiagnosticosDTO
    {
        public List<Diagnostico> Diagnosticos { get; set; }
        public int NumeroPaginas { get; set; }
        public int PaginaAtual { get; set; }
    }
}
