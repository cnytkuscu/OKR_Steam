﻿namespace OKR_Steam.Middlewares
{
    public class ResponseCheckMiddleware
    {
        private RequestDelegate _requestDelegate;
        public ResponseCheckMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            await _requestDelegate.Invoke(context);
            if(context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                await context.Response.WriteAsync("Sayfa bulunamadi");
            }
        }
    }
}
