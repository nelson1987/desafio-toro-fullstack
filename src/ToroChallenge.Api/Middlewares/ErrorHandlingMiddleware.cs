using Serilog;
using System.Net;

namespace ToroChallenge.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(true);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Log.Error(exception, "Error");

            var code = HttpStatusCode.InternalServerError;

            var result = System.Text.Json.JsonSerializer.Serialize(new { error = exception?.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
