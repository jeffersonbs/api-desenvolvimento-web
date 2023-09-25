using Projeto.Business.Models;

namespace Projeto.Business.Interfaces
{
    public interface ICIDRepository : IDisposable
    {
        Task<List<CID>> ListarCID(int pagina);
        Task<CID> ObterCIDPorId(int id);
        Task Adicionar(CID cid);
        Task Atualizar(CID cid);
        Task Deletar(CID cid);
        int NumeroCIDs();
    }
}
