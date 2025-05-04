using DHA.Common.Log4Net;
using Microsoft.AspNetCore.Http.Extensions;
using System.Globalization;

namespace DHA.CustomMiddleWare;

public class RequestDurationMiddleware
{
    private readonly RequestDelegate _next;

    public RequestDurationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext pHttpContext)
    {
        var ld = sLog4NetLogger.Info_Start($"REQUEST_PATH:[ {pHttpContext.Request.Path} ]",false);

        // Call the next delegate/middleware in the pipeline.
        await _next(pHttpContext);

        sLog4NetLogger.Info_End(ld);
    }
}

public static class RequestDurationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestDuration(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestDurationMiddleware>();
    }
}