using System;
using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class Transacao : EntidadeIdentidade
    {
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public int TransacaoTipoId { get; set; }
        public TransacaoTipo TransacaoTipo { get; set; }
        public int ContaId { get; set; }
        public Conta Conta { get; set; }
    }
}
