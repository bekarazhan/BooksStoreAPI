using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

public class FakeAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public FakeAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "DemoUser"),
            new Claim(ClaimTypes.Role, "Student"),
            // You can add more claims if needed
        };

        var identity = new ClaimsIdentity(claims, "FakeAuthentication");
        context.User = new ClaimsPrincipal(identity);

        await _next(context);
    }
}
