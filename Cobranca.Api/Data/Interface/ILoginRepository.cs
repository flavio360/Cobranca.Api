using Cobranca.Api.Models.Seguranca;

namespace Cobranca.Api.Data.Interface
{
    public interface ILoginRepository

    {
        Task<LoginModelRetorno> Autenticacao(string login);

    }
}
