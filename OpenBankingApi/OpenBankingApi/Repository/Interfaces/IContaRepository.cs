using System.Threading.Tasks;

namespace OpenBankingApi.Repository.Interfaces
{
    public interface IContaRepository
    {
        Task<decimal> GetSaldoPor(long cpf);
    }
}
