using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class Conta : EntidadeBase
    {
        [Required]
        public long Numero { get; set; }
        [Required]
        public int Agencia { get; set; }
        public int BancoId { get; set; }
        public decimal Saldo { get; set; }
        public Banco Banco { get; set; }
        public int ContaTipoId { get; set; }
        public ContaTipo ContaTipo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
