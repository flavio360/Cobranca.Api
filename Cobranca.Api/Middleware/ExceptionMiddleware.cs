using Cobranca.Api.Exceptions;
using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continua o pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // Loga o erro
            _logger.LogError(ex, "Erro não tratado na API");

            // Configura resposta HTTP
            context.Response.ContentType = "application/json";

            // Pode customizar status conforme tipo da exceção
            context.Response.StatusCode = ex is BusinessException ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                status = context.Response.StatusCode,
                mensagem = ex.Message
            };

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
