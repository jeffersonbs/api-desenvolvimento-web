using System.Text.Json.Serialization;

namespace Projeto.Business.Models
{
    public class CID
    {
        public int Id { get; set; }
        public string NomeDoenca { get; set; }
        public string CodCID { get; set; }
        [JsonIgnore]
        public ICollection<Diagnostico> Diagnosticos { get; private set; }
    }
}
