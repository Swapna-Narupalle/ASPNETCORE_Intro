using Introduction.Services;


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
                string status = _jwtauthetnicationService.ValidateToken(authizationToken);

                if (status == "Valid")
                {
                    context.Response.Headers["MyTokenisValidOrnot"] = status;
                    await _next(context); //respetive action
                }
                else
                {
                    context.Response.Headers["MyTokenisValidOrnot"] = status;
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