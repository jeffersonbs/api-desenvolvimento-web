using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Business.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UFRG { get; set; }
        public string OrgaoEmissor { get; set; }
        public string? NomePai { get; set; }
        public string NomeMae { get; set; }
        public string NumeroFone { get; set; }
        public Endereco? Endereco { get; set; }
        public int? EnderecoId { get; set; }
        public ICollection<Atendimento> Atendimentos { get; private set; }
    }
}
