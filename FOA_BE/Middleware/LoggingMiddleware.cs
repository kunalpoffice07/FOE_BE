namespace FOA_BE.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;   
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request coming on the path {context.Request.Path} and method {context.Request.Method}");

            await _next(context);   

            _logger.LogInformation($"We got the response status as {context.Response.StatusCode} on {nameof(LoggingMiddleware)} ");

        }

    }
}
