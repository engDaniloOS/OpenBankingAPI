using Microsoft.EntityFrameworkCore;
using OpenBankingApi.Infrastructure;
using OpenBankingApi.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository
{
    public class ContaRepository : IContaRepository
    {
        #region Campos
        private readonly Contexto contexto;
        #endregion Campos

        #region Construtores
        public ContaRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion Construtores

        public async Task<decimal> GetSaldoPor(long cpf)
        {
            var conta = await contexto.Contas.Where(c => c.IsAtivo && c.Cliente.Pessoa.Cpf == cpf).FirstOrDefaultAsync();
            return conta.Saldo;
        }
    }
}
