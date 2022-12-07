
using Microsoft.AspNetCore.Http;
using RequestResponseLogger.Interfaces;
using RequestResponseLogger.Models;

namespace RequestResponseLogger.Middleware
{
    public class RequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestResponseLogger _logger;
        public RequestResponseLoggerMiddleware(RequestDelegate next, IRequestResponseLogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext, IRequestResponseLogModelCreator logCreator)
        {
            RequestResponseLogModel log = logCreator.LogModel;

            log.RequestDateTime = DateTime.Now;
            HttpRequest request = httpContext.Request;

            log.RequestMethod = request.Method;
            log.RequestPath = request.Path;
            log.RequestBody = await ReadBodyFromRequest(request);
            log.RequestContentType = request.ContentType;

            HttpResponse response = httpContext.Response;
            var originalResponseBody = response.Body;
            using var newResponseBody = new MemoryStream();
            response.Body = newResponseBody;

            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                LogError(log, exception);
            }
            var responseBodyText = string.Empty;
            try
            {
                newResponseBody.Seek(0, SeekOrigin.Begin);
                responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();

                newResponseBody.Seek(0, SeekOrigin.Begin);
                await newResponseBody.CopyToAsync(originalResponseBody);
            }
            catch (Exception ex)
            {

                throw;
            }
            log.ResponseContentType = response.ContentType;
            log.ResponseStatus = response.StatusCode.ToString();

            log.ResponseBody = responseBodyText;
            log.ResponseDateTime = DateTime.Now;

            _logger.Log(logCreator);
        }

        private async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            request.EnableBuffering();
            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();
            request.Body.Position = 0;
            return requestBody;
        }
        private void LogError(RequestResponseLogModel log, Exception exception)
        {
            log.ExceptionMessage = exception.Message;
            log.ExceptionStackTrace = exception.StackTrace;
        }

    }
}
