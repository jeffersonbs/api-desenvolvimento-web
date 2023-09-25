using Projeto.Business.Models;

namespace Projeto.Business.Interfaces
{
    public interface IDiagnosticoRepository : IDisposable
    {
        Task<List<Diagnostico>> ListarDiagnostico(int pagina);
        Task<Diagnostico> ObterDiagnosticoPorId(int id);
        Task Adicionar(Diagnostico diagnostico);
        Task Atualizar(Diagnostico diagnostico);
        Task Deletar(Diagnostico diagnostico);
        Task AdicionarDiagnosticoCID(Diagnostico diagnostico, CID cid);
        int NumeroDiagnosticos();
    }
}
