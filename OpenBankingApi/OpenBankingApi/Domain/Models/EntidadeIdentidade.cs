using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public abstract class EntidadeIdentidade : IEntidadeIdentidade
    {
        [Key]
        public int Id { get; set; }
    }
}
