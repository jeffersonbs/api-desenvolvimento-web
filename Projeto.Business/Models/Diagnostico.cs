namespace Projeto.Business.Models
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public DateTime DataDiagnostico { get; set; }
        public ICollection<CID> CIDs { get; private set; }
    }
}
