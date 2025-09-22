using Cobranca.Api.Data.Interface;
using Cobranca.Api.Models;
using Cobranca.Api.Service.Interface;

namespace Cobranca.Api.Service
{
    public class CobrancaService : ICobrancaService
    {
        private readonly ICobrancaRepository _cobrancaRepository;

        public CobrancaService(ICobrancaRepository cobrancaRepository)
        {
            _cobrancaRepository = cobrancaRepository;
        }

        public async Task<List<string>> InsereNovaCobranca(List<OrigemModel> novaOrigem)
        {
            
            (bool Condicao, string Mensagem) resultado;

            List<string>  novaOrigemRet = new List<string>();

            foreach (var item in novaOrigem)
            {
                resultado = await _cobrancaRepository.InsereNovaCobranca(item);

                if (resultado.Condicao)
                    novaOrigemRet.Add(item.IdExterno + "Criado com sucesso");
                else
                    novaOrigemRet.Add(item.IdExterno + "Erro na tentativa de criação");
            }

            return novaOrigemRet;
        }
    }
}
