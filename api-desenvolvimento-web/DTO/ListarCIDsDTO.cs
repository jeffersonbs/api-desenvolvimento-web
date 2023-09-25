using Projeto.Business.Models;

namespace api_desenvolvimento_web.DTO
{
    public class ListarCIDsDTO
    {
        public List<CID> CIDs { get; set; }
        public int NumeroPaginas { get; set; }
        public int PaginaAtual { get; set; }
    }
}
