using Cobranca.Api.Models.Seguranca;

namespace Cobranca.Api.Service.Interface
{
    public interface ILoginService
    {
        Task<LoginModelRetorno> Autentticacao(LoginModelRequest login);
    }
}
