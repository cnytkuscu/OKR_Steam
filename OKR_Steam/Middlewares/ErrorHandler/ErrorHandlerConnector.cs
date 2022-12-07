namespace OKR_Steam.Middlewares.ErrorHandler
{
    public static class ErrorHandlerConnector
    {
        public static void ErrorHandlerMiddlewareConnector(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
