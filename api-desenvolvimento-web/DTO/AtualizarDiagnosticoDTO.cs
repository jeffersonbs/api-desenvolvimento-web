using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class AtualizarDiagnosticoDTO
    {
        [Required]
        public int? Id { get; set; }
        public DateTime? DataDiagnostico { get; set; }
    }
}
