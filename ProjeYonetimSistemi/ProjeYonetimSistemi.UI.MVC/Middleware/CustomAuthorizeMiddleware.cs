using Microsoft.AspNetCore.Authorization;

namespace ProjeYonetimSistemi.UI.MVC.Middleware
{
    public class CustomAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthorizationService authorizationService)
        {
            // Özel yetkilendirme için örnek kontrol (örneğin: admin rolü)
            if (context.Request.Path.StartsWithSegments("/admin"))
            {
                var authorizeResult = await authorizationService.AuthorizeAsync(context.User, null, "RequireAdminRole");

                if (!authorizeResult.Succeeded)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Yetkiniz yok.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
