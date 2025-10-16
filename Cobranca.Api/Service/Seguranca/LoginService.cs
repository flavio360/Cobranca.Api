using Cobranca.Api.Data.Interface;
using Cobranca.Api.Exceptions;
using Cobranca.Api.Models.Seguranca;
using Cobranca.Api.Service.Interface;
using System.Text.Json;

namespace Cobranca.Api.Service.Seguranca
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginModelRetorno> Autentticacao(LoginModelRequest login)
        {
            var _login = new LoginModel();

            if (login.Email == null)
                throw new BusinessException("O campo Usuario precisa ser informado");
            if (login.Email == null)
                throw new BusinessException("O campo Senha precisa ser informado");

            _login.Email = login.Email;
            _login.HashSenha = login.HashSenha;

            var json = JsonSerializer.Serialize(_login);


            var ret = await _loginRepository.Autenticacao(json);


            if (ret.UsuarioId == 0)
                throw new BusinessException("Usuário não encontrado ou Senha errada.");


            return ret;
        }
    }
}
