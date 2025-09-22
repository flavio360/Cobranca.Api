using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cobranca.Api.Config.Swagger
{
    public class ImpSwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;

            operation.Deprecated |= apiDescription.IsDeprecated();

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "Impacto-Api-Token",
                In = ParameterLocation.Header,
                AllowEmptyValue = false
            });


            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions?.Where(p => p.Name == parameter.Name).FirstOrDefault();

                if (description != null)
                {
                    if (parameter.Description is null)
                    {
                        parameter.Description = description.ModelMetadata?.Description;
                    }

                    if (parameter.Schema.Default is null && description.DefaultValue is not null)
                    {
                        parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
                    }

                    parameter.Required |= description.IsRequired;
                }
            }
        }
    }
}

