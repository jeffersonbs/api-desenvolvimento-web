﻿using System.Text.Json.Serialization;

namespace Projeto.Business.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime Data {get; set;}
        public string NumeroCarteira { get; set; }
        public double? PesoPaciente { get; set; }
        public double? AlturaPaciente { get; set; }
        public bool Aberto { get; set; }
        public DateTime? DataFim { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
        [JsonIgnore]
        public Paciente Paciente { get; set; }
        [JsonIgnore]
        public Profissional Profissional { get; set; }
    }
}
