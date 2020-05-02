using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models.Dtos
{
    public class CredenciaisDto
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
