﻿using Microsoft.EntityFrameworkCore;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;

namespace Projeto.Data.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ApplicationDbContext _contexto;
        public AtendimentoRepository(ApplicationDbContext contexto)
        {

            _contexto = contexto;

        }
        public async Task Adicionar(Atendimento atendimento)
        {
            _contexto.Add(atendimento);
            _contexto.SaveChanges();
        }

        public async Task Atualizar(Atendimento atendimento)
        {
            _contexto.Update(atendimento);
            _contexto.SaveChanges();
        }

        public async Task Deletar(Atendimento atendimento)
        {
            _contexto.Atendimentos.Remove(atendimento);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public Task FecharAtendimento(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Atendimento>> ListarAtendimentos()
        {
            return await _contexto.Atendimentos.ToListAsync();
        }

        public async Task<Atendimento> ObterAtendimentoPorId(int id)
        {
            return await _contexto.Atendimentos.FindAsync(id);
        }
    }
}
