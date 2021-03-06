﻿using OpenBankingApi.Domain.Models;
using OpenBankingApi.Domain.Models.Dtos;
using OpenBankingApi.Domain.Services.Interfaces;
using OpenBankingApi.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace OpenBankingApi.Domain.Services
{
    public class LoginService : ILoginService
    {
        #region Campos
        private readonly ILoginRepository repository;
        #endregion

        public LoginService(ILoginRepository repository) => this.repository = repository;

        public async Task<Credenciais> Autenticar(CredenciaisDto credenciais)
        {
            try
            {
                var resultado = await repository.GetAutenticado(credenciais);
                return resultado ?? new Credenciais(); 
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
