namespace Projeto.Business.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime Data {get; set;}
        public string NumeroCarteira { get; set; }
        public double? PesoPaciente { get; set; }
        public double? AlturaPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public Profissional Profissional { get; set; }
    }
}
