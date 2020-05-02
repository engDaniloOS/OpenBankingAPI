using OpenBankingApi.Domain.Enumerables;
using OpenBankingApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBankingApi.Domain.Services
{
    public interface ITransacaoService
    {
        string Erro { get; set; }
        Task<List<Transacao>> ListarTransacoes(long usuarioCpf, PeriodoExtrato periodoId);
        Task<Transacao> Depositar(long usuarioCpf, decimal valor);
        Task<Transacao> Sacar(long usuarioCpf, decimal valor);
    }
}
