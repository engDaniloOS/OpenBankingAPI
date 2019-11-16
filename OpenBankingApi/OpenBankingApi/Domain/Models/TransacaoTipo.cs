using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class TransacaoTipo : EntidadeBase
    {
        [Required]
        [MaxLength(200)]
        public string Tipo { get; set; }
    }
}
