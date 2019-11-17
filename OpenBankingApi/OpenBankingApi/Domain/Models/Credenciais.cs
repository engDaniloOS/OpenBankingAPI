namespace OpenBankingApi.Domain.Models
{
    public class Credenciais : EntidadeBase
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
