namespace WebAPI
{
    public class DisplayRequestInfoMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public DisplayRequestInfoMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("Information");
        }

        public async Task Invoke(HttpContext context)
        {
            var statusResponse = context.Response.StatusCode;
            _logger.Log(LogLevel.Information, statusResponse.ToString());

            await _next.Invoke(context);
            _logger.Log(LogLevel.Information, "Display request middleware finished");
            _logger.Log(LogLevel.Information, context.Request.Method);
        }
    }
}
