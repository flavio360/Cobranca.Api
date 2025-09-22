using Cobranca.Api.Models;

namespace Cobranca.Api.Data.Interface
{
    public interface ICobrancaRepository
    {
        Task<(bool, string)> InsereNovaCobranca(OrigemModel novaOrigem);
    }
}
