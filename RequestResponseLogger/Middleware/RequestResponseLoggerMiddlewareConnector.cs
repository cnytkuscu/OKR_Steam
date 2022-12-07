using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseLogger.Middleware
{
    public static class RequestResponseLoggerMiddlewareConnector
    {
        public static void RequestResponseLogger(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggerMiddleware>();
        }
    }
}
