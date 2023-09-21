﻿using Projeto.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class CriarPacienteDTO
    {
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public string? UFRG { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? NomePai { get; set; }
        public string? NomeMae { get; set; }
        public string? NumeroFone { get; set; }
        public CriarEndereco? Endereco { get; set; }
        public int? EnderecoId { get; set; }
        public ICollection<Atendimento>? Atendimentos { get; private set; }
    }

    public class CriarProfissionalDTO
    {
        public string Nome { get; set; }
        public string NumeroConselho { get; set; }
        public string UFConselho { get; set; }
        public string Especialidade { get; set; }
    }
}
