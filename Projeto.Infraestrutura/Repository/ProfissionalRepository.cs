using Microsoft.EntityFrameworkCore;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;

namespace Projeto.Data.Repository
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly ApplicationDbContext _contexto;
        public ProfissionalRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task Adicionar(Profissional profissional)
        {
            _contexto.Add(profissional);
            _contexto.SaveChanges();
        }

        public async Task Atualizar(Profissional profissional)
        {
            _contexto.Update(profissional);
            _contexto.SaveChanges();
        }

        public async Task Deletar(Profissional profissional)
        {
            _contexto.Profissionais.Remove(profissional);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<List<Profissional>> ListarProfissional()
        {
            return await _contexto.Profissionais.ToListAsync();
        }

        public async Task<Profissional> ObterProfissionalPorId(int id)
        {
            return await _contexto.Profissionais.FindAsync(id);
        }
    }
}
