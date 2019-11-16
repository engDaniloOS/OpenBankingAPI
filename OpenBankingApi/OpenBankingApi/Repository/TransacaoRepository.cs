using Microsoft.EntityFrameworkCore;
using OpenBankingApi.Domain.Enumerables;
using OpenBankingApi.Domain.Models;
using OpenBankingApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository
{
    public class TransacaoRepository : ITrasacaoRepository
    {
        #region Campos
        private readonly Contexto contexto;
        #endregion Campos

        #region Construtores
        public TransacaoRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion Construtores

        #region Metodos auxiliares
        private async Task<Transacao> Operacoes(Cliente cliente, decimal valor, TransacaoTipos tipo)
        {
            using (var transaction = contexto.Database.BeginTransaction())
            {
                try
                {
                    var conta = await contexto.Contas
                            .Where(c => c.IsAtivo && c.Cliente.Pessoa.Cpf == cliente.Pessoa.Cpf).FirstOrDefaultAsync();

                    if (conta == null) return new Transacao(); ;

                    conta.Saldo = (tipo == TransacaoTipos.SAQUE) ? conta.Saldo - valor :
                                  (tipo == TransacaoTipos.DEPOSITO) ? conta.Saldo + valor :
                                                                      conta.Saldo;

                    contexto.Entry(conta).State = EntityState.Modified;
                    contexto.Update(conta);
                    await contexto.SaveChangesAsync();

                    var transacaoBancaria = new Transacao()
                    {
                        Data = DateTime.Now,
                        ContaId = conta.Id,
                        Valor = valor,
                        TransacaoTipoId = (int)tipo
                    };

                    await contexto.Transacaoes.AddAsync(transacaoBancaria);
                    await contexto.SaveChangesAsync();

                    transaction.Commit();

                    return await contexto.Transacaoes.Where(t => t.Id == transacaoBancaria.Id).Include(t => t.Conta).FirstOrDefaultAsync();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }
        #endregion Metodos auxiliares

        public async Task<List<Transacao>> ListarTransacoes(Cliente cliente, int periodoId)
        => await contexto.Transacaoes
                            .Where(t => t.Conta.ClienteId == cliente.Id && t.Data >= t.Data.AddDays(periodoId * -1))
                            .Include(t => t.TransacaoTipo)
                            .Include(t => t.Conta)
                            .ToListAsync();

        public async Task<Transacao> Depositar(Cliente cliente, decimal valor)
            => await Operacoes(cliente, valor, TransacaoTipos.DEPOSITO);

        public async Task<Transacao> Sacar(Cliente cliente, decimal valor)
            => await Operacoes(cliente, valor, TransacaoTipos.SAQUE);
    }
}
