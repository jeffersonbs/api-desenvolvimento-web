using Projeto.Business.Models;

namespace Projeto.Business.Interfaces
{
    public interface IProfissionalRepository : IDisposable
    {
        Task<List<Profissional>> ListarProfissional(int pagina);
        Task<Profissional> ObterProfissionalPorId(int id);
        Task Adicionar(Profissional profissional);
        Task Atualizar(Profissional profissional);
        Task Deletar(Profissional profissional);
        int NumeroProfissionais();
    }
}
