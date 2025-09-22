using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cobranca.Api.Config.Swagger
{
    public class ImpSwaggerGenOptions
    {
        public static void ConfigureSwaggerGenOptions(SwaggerGenOptions options)
        {
            AddSwaggerXmlComments(options);
            options.OperationFilter<ImpSwaggerDefaultValues>();
        }

        private static void AddSwaggerXmlComments(SwaggerGenOptions o)
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }
}
