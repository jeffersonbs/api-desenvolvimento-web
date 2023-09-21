using Projeto.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Interfaces
{
    public interface IPacienteRepository : IDisposable
    {
        Task<List<Paciente>> ListarPacientes();
        Task<Paciente> ObterPacientePorId(int id);
        Task Adicionar(Paciente paciente);
        Task Atualizar(Paciente paciente);
        Task Deletar(Paciente paciente);
        Task AtualizarEndereco(Endereco endereco);
        Task<Endereco> ObterEnderecoPorId(int id);
    }
}
