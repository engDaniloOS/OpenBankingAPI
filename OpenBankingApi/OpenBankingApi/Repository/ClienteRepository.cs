using Microsoft.EntityFrameworkCore;
using OpenBankingApi.Domain.Models;
using OpenBankingApi.Infrastructure;
using OpenBankingApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        #region Campos
        private readonly Contexto contexto;
        #endregion Campos

        #region Construtores
        public ClienteRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion Construtores

        public async Task<Cliente> GetClientePor(long cpf)
            => await contexto.Cliente
                             .Where(c => c.Pessoa.Cpf == cpf && c.Pessoa.Cliente.IsAtivo)
                             .Include(c => c.Pessoa)
                             .FirstOrDefaultAsync();
    }
}
