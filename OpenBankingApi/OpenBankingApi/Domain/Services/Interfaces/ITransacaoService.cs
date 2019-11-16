using OpenBankingApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBankingApi.Domain.Services
{
    public interface ITransacaoService
    {
        string Erro { get; set; }
        Task<List<Transacao>> ListarTransacoes(long usuarioCpf, int periodoId);
        Task<Transacao> Depositar(long usuarioCpf, decimal valor);
        Task<Transacao> Sacar(long usuarioCpf, decimal valor);
    }
}
