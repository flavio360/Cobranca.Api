using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cobranca.Api.Config.Swagger
{
    public class ImpConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ImpConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Configure Swagger Options. Inherited from the Interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }


        /// <summary>
        /// Configure each API discovered for Swagger Documentation
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        /// <summary>
        /// Create information about the version of the API
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Information about the API</returns>
        private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
        {
            var info = new OpenApiInfo()
            {
                Version = $"Versão Imapcto Cobrança -{desc.ApiVersion}",
                Title = "Imapcto Cobrança Api",
                Description = $"Imapcto Cobrança - Nova Ordem <br>" +
                              $"Ambiente: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} <br>" +
                              $"Maquina: {Environment.MachineName}",
                Contact = new OpenApiContact()
                {
                    Name = "Tecnologia",
                    Email = "tecnologia@impactocobranca.com.br"
                },
                License = new OpenApiLicense
                {
                    Name = "Politica - Impacto",
                    Url = new Uri("https://www.impactoCobranca.com.br") // precisa do https://
                },
                TermsOfService = new Uri("https://www.impactoCobranca.com.br") // precisa do https://
            };


            if (desc.IsDeprecated)
            {
                info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
            }

            return info;
        }
    }
}
