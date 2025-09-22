using Cobranca.Api.Config.Helpers;
using Cobranca.Api.Models;
using Cobranca.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.Api.Controllers
{
    [SecurityHelper.Authorize]
    [ApiController]
    [Route("api/Impacto/Cobranca")]
    public class CobrancaController : ControllerBase
    {
        private ICobrancaService _cobrancaService;
        public CobrancaController(ICobrancaService cobrancaService) 
        {
            _cobrancaService = cobrancaService;
        }

        [HttpPost("Teste")]
        public async Task<IActionResult> teste()
        {
            if (true)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro");
            }
        }

        [HttpPost("Nova")]
        public async Task<IActionResult> NovaCobranca([FromBody] List<OrigemModel> origem)
        {
            var retorno = await _cobrancaService.InsereNovaCobranca(origem);

            if (true)
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest(retorno);
            }
        }


    }
}
