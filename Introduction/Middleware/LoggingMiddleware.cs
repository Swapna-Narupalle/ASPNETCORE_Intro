namespace Introduction
{
    public class LoggingMiddleware
    {
        RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)   //Gatekeeper
        {

            var httpContextHeaders = context.Request.Headers;
            var httpContextBody = context.Request.Body;
            var httpContextPath = context.Request.Path;
            var httpContextQueryString = context.Request.QueryString;

            Console.WriteLine("==========Request headers =================");
            Console.WriteLine($"httpContextHeaders : {httpContextHeaders}");
            Console.WriteLine($"httpContextBody    : {httpContextHeaders}");
            Console.WriteLine($"httpContextPath    : {httpContextPath}");
            Console.WriteLine($"httpContextQueryString : {httpContextQueryString}");
            Console.WriteLine("=====================================");


            await _next(context);
        }
    }
}