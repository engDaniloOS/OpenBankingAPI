using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBankingApi.Domain.Models;

namespace OpenBankingApi.Repository
{
    public interface ITrasacaoRepository
    {
        Task<List<Transacao>> ListarTransacoes(Cliente cliente, int periodoId);
        Task<Transacao> Depositar(Cliente cliente, decimal valor);
        Task<Transacao> Sacar(Cliente cliente, decimal valor);
    }
}