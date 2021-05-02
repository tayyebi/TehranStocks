using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TehranStocks.Middleware
{
    public class AccessMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (false)
            {
                await context.Response.WriteAsync("Request not allowed");
                return;
            }
            else
                await next(context);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}