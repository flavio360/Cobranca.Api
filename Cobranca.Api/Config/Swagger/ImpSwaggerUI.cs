using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Cobranca.Api.Config.Swagger
{
    public class ImpSwaggerUI
    {
        public static void ConfigureSwaggerUI(WebApplication app)
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        $"Impacto-{description.GroupName.Replace("v", "").ToUpper()}");

                    options.RoutePrefix = string.Empty;

                }

                options.DocExpansion(DocExpansion.List);

                options.InjectStylesheet("/swagger-ui/custom.css");
            });

            app.UseStaticFiles();
        }
    }
}
