using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBankingApi.Domain.Enumerables;
using OpenBankingApi.Domain.Models;
using OpenBankingApi.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransacoesController : ControllerBase
    {
        #region Campos
        private readonly ITransacaoService service;
        
        private readonly string msgNaoEncontrado = "Usuário e/ou conta estão intativo(s), inválido(s) ou não encontrado(s)";
        #endregion Campos

        #region Construtores
        public TransacoesController(ITransacaoService service)
        {
            this.service = service;
        }
        #endregion Construtores

        #region Métodos auxiliares
        private IActionResult MontarResultado(Transacao transacao, string mensagem)
        {
            if (transacao == null)
                return BadRequest(mensagem);

            if (transacao.Conta == null)
                return NotFound(msgNaoEncontrado);

            return Ok(new { novoSaldo = transacao.Conta.Saldo });
        }
        #endregion Métodos auxiliares

        [HttpGet]
        [Route("{periodoId}/{usuariocpf}")]
        public async Task<IActionResult> ConsultarExtrato(long usuarioCpf, int periodoId = (int)PeriodoExtrato.MES)
        {
            var transacoes = await service.ListarTransacoes(usuarioCpf, periodoId);
           
            if (transacoes == null)
                return BadRequest(service.Erro);

            else if (transacoes.Count == 0)
                return NoContent();

            else
            {
                return Ok(from transacao in transacoes
                          select new
                          {
                              tipo = transacao.TransacaoTipo.Tipo,
                              valor = transacao.Valor,
                              saldo = transacao.Conta.Saldo,
                              data = transacao.Data.ToString("dd/MM/yyyy"),
                              hora = transacao.Data.ToString("HH:mm:ss"),
                          });
            }

        }

        [HttpPost]
        [Route("depositar/{clientecpf}")]
        public async Task<IActionResult> RealizarDeposito(long clientecpf, [FromBody]decimal valor)
            => MontarResultado(await service.Depositar(clientecpf, valor), service.Erro);

        [HttpPost]
        [Route("sacar/{clientecpf}")]
        public async Task<IActionResult> RealizarSaque(long clientecpf, [FromBody]decimal valor)
            => MontarResultado(await service.Sacar(clientecpf, valor), service.Erro);

    }
}