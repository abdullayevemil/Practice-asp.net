
using Microsoft.AspNetCore.Http.Extensions;

namespace Turbo.az.Middlewares;
public class LogMiddleware : IMiddleware
{
    private readonly ILogger<LogMiddleware> logger;

    public LogMiddleware(ILogger<LogMiddleware> logger) => this.logger = logger;

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        using StreamReader requestReader = new(httpContext.Request.Body);
        var requestBody = requestReader.ReadToEndAsync();
        using StreamReader responseReader = new(httpContext.Response.Body);
        var responseBody = responseReader.ReadToEndAsync();
        var statusCode = httpContext.Response.StatusCode;
        var httpMethod = httpContext.Request.Method;
        var ulr = httpContext.Request.GetDisplayUrl();
        await next.Invoke(httpContext);
    }
}

public class SqlLogger : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        throw new NotImplementedException();
    }
}