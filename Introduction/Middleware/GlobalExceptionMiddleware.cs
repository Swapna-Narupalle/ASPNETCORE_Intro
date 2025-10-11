using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Introduction.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            await Task.Delay(1000);

            int status = 0;

            switch (ex)
            {
                case DivideByZeroException:
                    status = (int)HttpStatusCode.BadRequest;  //400
                    break;
                case ForbiddenException:
                    status = (int)HttpStatusCode.Forbidden;    //403
                    break;
                case ConflictException:
                    status = (int)HttpStatusCode.Conflict;    //409
                    break;
                case ValidationException:
                    status = (int)HttpStatusCode.BadRequest;   //400
                    break;
                case UnauthorizedAccessException:
                    status = (int)HttpStatusCode.Unauthorized; // 401
                    break;
                case KeyNotFoundException:
                    status = (int)HttpStatusCode.NotFound;   //404
                    break;
                default:
                    status = (int)HttpStatusCode.InternalServerError;  //500
                    break;
            }

            Console.WriteLine($"Exceptoin caught : {ex.Message}, Status : {status} , Path: {context.Request.Path} ");


            var payLoad = new
            {
                status = status,
                ErrorMessage = ex.Message,
                Path = context.Request.Path
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";

            // Object into string --> Serilalzation technique

            string jsonString = JsonSerializer.Serialize(payLoad);

            await context.Response.WriteAsync(jsonString);

            //Console.WriteLine(ex.Message.ToString());  // we will focus...
        }





    }
}