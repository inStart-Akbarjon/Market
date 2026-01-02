using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace Market.Application.Extensions.Product;

public static class MiddlewareRegistrationServiceExtension
{
    public static WebApplication AddMiddlewareRegistrationServiceExtension(this WebApplication app)
    {
        // app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        return app;
    }
}