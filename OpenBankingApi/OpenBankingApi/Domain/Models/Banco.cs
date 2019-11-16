using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class Banco : EntidadeBase
    {
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        public long Codigo { get; set; }
        [Required]
        public long Cnpj { get; set; }
    }
}
