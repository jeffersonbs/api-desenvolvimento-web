using Projeto.Business.Models;

namespace api_desenvolvimento_web.DTO
{
    public class ListarPacientesDTO
    {
        public List<Paciente> Pacientes { get; set; }
        public int NumeroPaginas { get; set; }
        public int PaginaAtual { get; set; }
    }
    public class ListarProfissionaisDTO
    {
        public List<Profissional> Profissional { get; set;}
        public int NumeroPaginas { get; set; }
        public int PaginaAtual { get; set; }
    }
}
