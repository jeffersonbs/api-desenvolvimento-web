using Projeto.Business.Models;

namespace Projeto.Business.Interfaces
{
    public interface IAtendimentoRepository : IDisposable
    {
        Task<List<Atendimento>> ListarAtendimentos();
        Task<Atendimento> ObterAtendimentoPorId(int id);
        Task Adicionar(Atendimento atendimento);
        Task Atualizar(Atendimento atendimento);
        Task Deletar(Atendimento atendimento);
        Task FecharAtendimento(int id);
    }
}
