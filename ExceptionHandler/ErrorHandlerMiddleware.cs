using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OKR_Steam.Business.IBS;
using OKR_Steam.Models.ResponseModels;
using RestSharp;

namespace ExceptionHandler
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorHandlerMiddleware : PageModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string? ExceptionMessage { get; set; }

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IErrorBusiness errorBusiness)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(errorBusiness, httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(IErrorBusiness errorBusiness, HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";  
            var errors = new List<string>();

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
