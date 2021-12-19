using Microsoft.AspNetCore.Builder;
using WEB_953501_BYSTROVA.Middleware;

namespace WEB_953501_BYSTROVA.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}
