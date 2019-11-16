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

            return Ok();
        }
        #endregion Métodos auxiliares

        [HttpGet]
        [Route("{usuariocpf}/{periodoId}")]
        public async Task<IActionResult> ConsultarExtrato(int usuarioCpf, int periodoId = (int)PeriodoExtrato.MES)
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
        [Route("depositar")]
        public async Task<IActionResult> RealizarDeposito([FromBody]long usuarioCpf, [FromBody]decimal valor)
            => MontarResultado(await service.Depositar(usuarioCpf, valor), service.Erro);

        [HttpPost]
        [Route("sacar")]
        public async Task<IActionResult> RealizarSaque([FromBody]long usuarioCpf, [FromBody]decimal valor)
            => MontarResultado(await service.Sacar(usuarioCpf, valor), service.Erro);

    }
}