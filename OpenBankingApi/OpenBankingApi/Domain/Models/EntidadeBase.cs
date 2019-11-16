using System;
using System.ComponentModel;

namespace OpenBankingApi.Domain.Models
{
    public abstract class EntidadeBase : EntidadeIdentidade, IEntidadeBase
    {
        [DefaultValue(false)]
        public bool IsAtivo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
