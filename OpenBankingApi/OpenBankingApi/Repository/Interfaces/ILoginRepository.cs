using OpenBankingApi.Domain.Models;
using OpenBankingApi.Domain.Models.Dtos;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<Credenciais> GetAutenticado(CredenciaisDto credenciais);
    }
}
