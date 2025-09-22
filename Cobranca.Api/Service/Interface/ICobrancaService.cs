using Cobranca.Api.Models;

namespace Cobranca.Api.Service.Interface
{
    public interface ICobrancaService
    {
        Task<List<string>> InsereNovaCobranca(List<OrigemModel> novaOrigem);
    }
}
