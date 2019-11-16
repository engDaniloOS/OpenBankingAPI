using System;
using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class Pessoa : EntidadeBase
    {
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required]
        public long Cpf { get; set; }
        public long Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
