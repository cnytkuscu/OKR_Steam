using Microsoft.AspNetCore.Builder;
namespace ExceptionHandler
{
    public static class ExceptionHandlerConnector
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}