using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class ClienteTipo : EntidadeBase
    {
        [Required]
        [MaxLength(30)]
        public string Tipo { get; set; }
    }
}
