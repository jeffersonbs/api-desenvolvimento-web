using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.EntityFrameworkCore;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _contexto;
        public PacienteRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Paciente paciente)
        {
            _contexto.Add(paciente);
            _contexto.SaveChanges();
        }

        public async Task<List<Paciente>> ListarPacientes()
        {
           return await _contexto.Pacientes
                .Include(x => x.Endereco)
                .Include(x => x.Diagnostico)
                .ToListAsync();
        }
        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<Paciente> ObterPacientePorId(int id)
        {
            return await _contexto.Pacientes.FindAsync(id);
        }

        public async Task Atualizar(Paciente paciente)
        {
            _contexto.Update(paciente);
            _contexto.SaveChanges();
        }

        public async Task Deletar(Paciente paciente)
        { 
            _contexto.Pacientes.Remove(paciente);
            _contexto.SaveChanges();
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            _contexto.Update(endereco);
            _contexto.SaveChanges();
        }

        public async Task<Endereco> ObterEnderecoPorId(int id)
        {
            return await _contexto.Enderecos.FindAsync(id);
        }
    }
}
