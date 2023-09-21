using Projeto.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_desenvolvimento_web.DTO
{
    public class AtualizarEnderecoDTO
    {
        [Required]
        public int? Id { get; set; }
        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Cep { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        [JsonIgnore]
        public Paciente? Paciente { get; set; }
    }
}
