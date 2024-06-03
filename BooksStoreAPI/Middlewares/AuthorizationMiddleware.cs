using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Perform authorization logic here
        if (!IsUserAuthorized(context.User))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        // Call the next middleware in the pipeline if authorization is successful
        await _next(context);
    }

    private bool IsUserAuthorized(ClaimsPrincipal user)
    {
        // Your authorization logic goes here
        // Check if the user has the necessary permissions/roles to access the resource
        // For example:
        return user.Identity.IsAuthenticated && user.IsInRole("Student");
    }
}
