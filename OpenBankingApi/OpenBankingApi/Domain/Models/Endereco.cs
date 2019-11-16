using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class Endereco : EntidadeBase, IEntidadeBase
    {

        [Required]
        public long Cep { get; set; }
        [Required]
        public int Numero { get; set; }
        [MaxLength(100)]
        public string Rua { get; set; }
        [MaxLength(100)]
        public string Bairro { get; set; }
        [MaxLength(100)]
        public string Estado { get; set; }
        [MaxLength(30)]
        public string Pais { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
