using OpenBankingApi.Domain.Models;
using System.Threading.Tasks;

namespace OpenBankingApi.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClientePor(long cpf);
    }
}
