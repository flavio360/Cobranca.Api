using AutoMapper;

namespace Cobranca.Api.Config.DataBase
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                // Nenhum mapeamento por enquanto
            });

            return mappingConfig;
        }
    }
}
