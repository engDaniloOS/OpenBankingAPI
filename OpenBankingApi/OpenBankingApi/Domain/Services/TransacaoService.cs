using OpenBankingApi.Domain.Enumerables;
using OpenBankingApi.Domain.Models;
using OpenBankingApi.Repository;
using OpenBankingApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBankingApi.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        public string Erro { get; set; }

        #region Campos
        private const string msgValorInvalido = "O valor solicitado para depósito é inválido!";
        private const string msgValorInsuficiente = "Não há saldo suficiente para sacar o valor desejado!";

        private readonly ITrasacaoRepository repository;
        private readonly IClienteRepository clienteRepository;
        private readonly IContaRepository contaRepository;
        #endregion Campos

        #region Construtores
        public TransacaoService(ITrasacaoRepository repository, IClienteRepository clienteRepository, IContaRepository contaRepository)
        {
            Erro = string.Empty;
            this.repository = repository;
            this.clienteRepository = clienteRepository;
            this.contaRepository = contaRepository;
        }
        #endregion Construtores

        #region Metodos auxiliares
        private async Task<Cliente> ValidaClientePor(long cpf)
        {
            var usuario = await clienteRepository.GetClientePor(cpf);

            if (usuario == null)
                throw new ArgumentException("Cliente inválido!");

            return usuario;
        }
        #endregion Metodos auxiliares

        public async Task<List<Transacao>> ListarTransacoes(long cpf, int periodoId)
        {
            try
            {
                if (!Enum.IsDefined(typeof(PeriodoExtrato), periodoId))
                    throw new ArgumentException("Período inválido!");

                return await repository.ListarTransacoes(await ValidaClientePor(cpf), periodoId);
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;
            }
        }

        public async Task<Transacao> Depositar(long usuarioCpf, decimal valor)
        {
            try
            {
                if (valor <= 0)
                    throw new ArgumentException(msgValorInvalido);

                return await repository.Depositar(await ValidaClientePor(usuarioCpf), valor);
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;
            }
        }

        public async Task<Transacao> Sacar(long usuarioCpf, decimal valor)
        {
            try
            {
                var cliente = await ValidaClientePor(usuarioCpf);
                var saldo = await contaRepository.GetSaldoPor(usuarioCpf);

                if (saldo - valor < 0)
                    throw new ArgumentException(msgValorInsuficiente);

                return await repository.Sacar(cliente, valor);
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;
            }
        }
    }
}
