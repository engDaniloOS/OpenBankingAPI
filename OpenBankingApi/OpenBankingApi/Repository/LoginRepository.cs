using Microsoft.EntityFrameworkCore;
using OpenBankingApi.Domain.Models;
using OpenBankingApi.Infrastructure;
using OpenBankingApi.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository
{
    public class LoginRepository : ILoginRepository
    {
        #region Campos
        private readonly Contexto contexto;
        #endregion

        #region Construtores
        public LoginRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion

        public async Task<Credenciais> GetAutenticado(Credenciais credenciais)
            => await contexto.Credenciais
                             .Where(c => c.IsAtivo && c.Usuario == credenciais.Usuario && c.Senha == credenciais.Senha)
                             .Include(c => c.Cliente)
                             .ThenInclude(c => c.Pessoa)
                             .FirstOrDefaultAsync();
    }
}
