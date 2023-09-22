using Microsoft.EntityFrameworkCore;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;
using System.Security.Cryptography;

namespace Projeto.Data.Repository
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly ApplicationDbContext _contexto;
        public DiagnosticoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task Adicionar(Diagnostico diagnostico)
        {
            _contexto.Add(diagnostico);
            _contexto.SaveChanges();
        }

        public async Task AdicionarDiagnosticoCID(Diagnostico diagnostico, CID cid)
        {
            diagnostico.CIDs.Add(cid);
            _contexto.SaveChanges();
        }

        public async Task Atualizar(Diagnostico diagnostico)
        {
            _contexto.Update(diagnostico);
            _contexto.SaveChanges();
        }

        public async Task Deletar(Diagnostico diagnostico)
        {
            _contexto.Diagnosticos.Remove(diagnostico);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<List<Diagnostico>> ListarDiagnostico()
        {
            return await _contexto.Diagnosticos.Include(x => x.CIDs).ToListAsync();
        }

        public async Task<Diagnostico> ObterDiagnosticoPorId(int id)
        {
            return await _contexto.Diagnosticos.Where(x => x.Id == id).Include(x => x.CIDs).FirstOrDefaultAsync();
        }
    }
}
