using OpenBankingApi.Domain.Models;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<Credenciais> GetAutenticado(Credenciais credenciais);
    }
}
