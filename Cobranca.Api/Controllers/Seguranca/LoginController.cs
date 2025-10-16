using Cobranca.Api.Config.Helpers;
using Cobranca.Api.Exceptions;
using Cobranca.Api.Models.Seguranca;
using Cobranca.Api.Service.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.Api.Controllers.Seguranca
{
    [SecurityHelper.Authorize]
    [ApiController]
    [Route("api/Impacto/Login")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] LoginModelRequest model)
        {
            var usuario = await _loginService.Autentticacao(model);
            return Ok(usuario);
        }

    }
}
