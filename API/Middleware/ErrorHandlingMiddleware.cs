using System.Net;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Chama o próximo Middleware na cadeia de execução
                await _next(context);
            }
            catch (Exception ex)
            {
                // Tratamento de erros personalizado
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Configura a resposta HTTP com o código de status e conteúdo apropriados
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "text/plain";

            // Escreve a mensagem de erro na resposta
            await context.Response.WriteAsync($"Ocorreu um erro: {ex.Message}");
        }
    }
}
