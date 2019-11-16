using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenBankingApi.Domain.Models
{
    public class Cliente : EntidadeBase
    {
        [Required]
        public long Registro { get; set; }
        public Pessoa Pessoa { get; set; }
        public int ClienteTipoId { get; set; }
        public ClienteTipo ClienteTipo { get; set; }
        public IList<Conta> Contas { get; set; }
    }
}