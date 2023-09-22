using Microsoft.EntityFrameworkCore;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;

namespace Projeto.Data.Repository
{
    public class CIDRepository : ICIDRepository
    {
        private readonly ApplicationDbContext _contexto;
        public CIDRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CID cid)
        {
            _contexto.Add(cid);
            _contexto.SaveChanges();
        }

        public async Task Atualizar(CID cid)
        {
            _contexto.Update(cid);
            _contexto.SaveChanges();
        }

        public async Task Deletar(CID cid)
        {
            _contexto.CIDs.Remove(cid);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<List<CID>> ListarCID()
        {
            return await _contexto.CIDs.ToListAsync();
        }

        public async Task<CID> ObterCIDPorId(int id)
        {
            return await _contexto.CIDs.FindAsync(id);
        }
    }
}
