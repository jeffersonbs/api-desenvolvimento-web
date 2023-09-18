namespace Projeto.Business.Models
{
    public class CID
    {
        public int Id { get; set; }
        public string CodCID { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; private set; }
    }
}
