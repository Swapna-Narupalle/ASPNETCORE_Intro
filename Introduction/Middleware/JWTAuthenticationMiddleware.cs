using Introduction.Services;
using System.Security.Claims;


namespace Introduction.Middleware
{
    public class JWTAuthenticationMiddleware
    {



        RequestDelegate _next;
        IJWTAuthenticationService _jwtauthetnicationService;
        public JWTAuthenticationMiddleware(RequestDelegate next, IJWTAuthenticationService jwtauthenticationService)
        {

            _next = next;
            _jwtauthetnicationService = jwtauthenticationService;
        }

        public async Task InvokeAsync(HttpContext context)   //Gatekeeper
        {

            if (context.Request.Path.ToString().Contains("Login"))
            {
                await _next(context);  //respetive action
                return;
            }

            var authizationToken = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authizationToken))
            {
                //details of the user called principle user identity name, role values
                ClaimsPrincipal principal = _jwtauthetnicationService.ValidateToken(authizationToken);

                if(principal != null)
                {
                    context.User = principal;
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }

            }
            else
            {
                context.Response.Headers["MyTokenisValidOrnot"] = "Plese give your token";
                return;
            }

        }
    }
}