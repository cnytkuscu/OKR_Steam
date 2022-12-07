using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OKR_Steam.Business.BS;
using OKR_Steam.DataAccess.DA;
using RestSharp;

namespace OKR_Steam.Middlewares
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorHandlerMiddleware : PageModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string? ExceptionMessage { get; set; }

        private readonly RequestDelegate _next;

        private readonly AppDbContext _context;

        public ErrorHandlerMiddleware(RequestDelegate next, AppDbContext context)
        {
            _next = next;
            _context = context;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(new ErrorBusiness(new ErrorDataAccess(_context)), context, ex);
            }
        }
        private async Task HandleExceptionAsync(IErrorBusiness errorBusiness, HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var errors = new System.Collections.Generic.List<string>();


            errors.Add("Beklenmedik bir hata oluştu." + exception.ToString() + Environment.NewLine + exception.StackTrace);

            var error = new ErrorModel
            {
                IsAuthenticated = context.User.Identity.IsAuthenticated,
                ExceptionType = exception.GetType().Name,
                StackTrace = exception.StackTrace,
                Message = exception.Message,
                StatusCode = context.Response.StatusCode,
                Date = DateTime.Now
            };

            errorBusiness.Insert(error);

            Enum.TryParse(typeof(ResponseStatus), error.StatusCode.ToString(), out var errorCode);
            var message = JsonConvert.SerializeObject(errors);

            await context.Response.WriteAsync(message);
        }
    }
}
