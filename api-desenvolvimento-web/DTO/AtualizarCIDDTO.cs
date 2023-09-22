using System.ComponentModel.DataAnnotations;

namespace api_desenvolvimento_web.DTO
{
    public class AtualizarCIDDTO
    {
        [Required]
        public int Id { get; set; }
        public string NomeDoenca { get; set; }
        public string CodCID { get; set; }
    }
}
