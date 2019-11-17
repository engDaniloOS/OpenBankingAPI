using OpenBankingApi.Domain.Models;
using System.Threading.Tasks;

namespace OpenBankingApi.Domain.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Credenciais> Autenticar(Credenciais credenciais);
    }
}
