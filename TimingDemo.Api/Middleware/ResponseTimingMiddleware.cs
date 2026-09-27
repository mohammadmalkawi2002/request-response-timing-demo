using Microsoft.Extensions.Options;
using System.Diagnostics;
using TimingDemo.Api.Options;

namespace TimingDemo.Api.Middleware
{
    public class ResponseTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseTimingMiddleware> _logger;
        private readonly PerformanceOptions _options;



        public ResponseTimingMiddleware(RequestDelegate next,ILogger<ResponseTimingMiddleware> logger,IOptions<PerformanceOptions> options )
        {
         _next = next;   
          _logger = logger;

            _options = options.Value;
        }



        public async Task InvokeAsync(HttpContext context) 
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation(
                "HTTP {Method} {Path} Started ......",
                context.Request.Method,
                context.Request.Path);

            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Response-Time-ms"] =
                    stopwatch.ElapsedMilliseconds.ToString();

                return Task.CompletedTask;
            });

            await _next(context);

            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            if (elapsedMilliseconds >= _options.SlowRequestThresholdMs)
            {
                _logger.LogWarning(
                    "Slow HTTP {Method} {Path} responded {StatusCode} finished in {ElapsedMilliseconds} ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    elapsedMilliseconds);
            }
            else
            {
                _logger.LogInformation(
                    "HTTP {Method} {Path} responded {StatusCode} finished in {ElapsedMilliseconds} ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    elapsedMilliseconds);
            }

        }
    }
}
