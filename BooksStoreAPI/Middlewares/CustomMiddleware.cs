using System.Diagnostics;

namespace BooksStoreAPI.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something before the request reaches the next middleware
            Debug.WriteLine("Before handling the request.");

            // Call the next middleware in the pipeline
            await _next(context);

            // Do something after the request has been handled by other middleware
            Debug.WriteLine("After handling the request.");
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
