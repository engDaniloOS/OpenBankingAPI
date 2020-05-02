using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenBankingApi.Domain.Models;
using OpenBankingApi.Domain.Models.Dtos;
using OpenBankingApi.Domain.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenBankingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Campos
        private const string msgErro = "Credenciais incorretas!";

        private readonly IConfiguration configuration;
        private readonly ILoginService service;
        #endregion

        #region Construtores
        public LoginController(ILoginService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }
        #endregion Construtores

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logar([FromBody] CredenciaisDto credenciais)
        {
            var autenticado = await service.Autenticar(credenciais);

            #region Não autorizado
            if (autenticado == null)
                return StatusCode(500);

            else if (autenticado.Usuario == null)
                return BadRequest(msgErro);
            #endregion

            #region Autorizado
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, autenticado.Cliente.Pessoa.Nome),
                new Claim(ClaimTypes.Email, autenticado.Usuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"]));
            
            var criptografia = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "openBanking",
                audience: "openBanking",
                claims: claims,
                expires: DateTime.Now.AddMinutes(4),
                signingCredentials: criptografia
                );

            return Ok(new { 
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
            #endregion autorizado
        }
    }
}