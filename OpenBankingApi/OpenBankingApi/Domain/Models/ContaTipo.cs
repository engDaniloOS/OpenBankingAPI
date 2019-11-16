using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class ContaTipo : EntidadeBase
    {
        [Required]
        [MaxLength(200)]
        public string Tipo { get; set; }
    }
}
