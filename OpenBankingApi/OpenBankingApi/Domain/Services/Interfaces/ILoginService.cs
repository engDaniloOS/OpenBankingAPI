using OpenBankingApi.Domain.Models;
using OpenBankingApi.Domain.Models.Dtos;
using System.Threading.Tasks;

namespace OpenBankingApi.Domain.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Credenciais> Autenticar(CredenciaisDto credenciais);
    }
}
