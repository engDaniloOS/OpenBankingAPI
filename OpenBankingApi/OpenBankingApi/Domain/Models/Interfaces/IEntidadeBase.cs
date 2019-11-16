using System;

namespace OpenBankingApi.Domain.Models
{
    public interface IEntidadeBase
    {
        DateTime DataCriacao { get; set; }
        DateTime DataModificacao { get; set; }
        bool IsAtivo { get; set; }
    }
}