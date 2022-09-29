using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExemploDeActionFilter.Filters
{
    public class FiltroDeAcessoInterno : ActionFilterAttribute
    {
        private const string TokenDeAcessoInternoPermitido = "123";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("tokenDeAcessoInterno", out var tokenDeAcessoInterno) && tokenDeAcessoInterno.Equals(TokenDeAcessoInternoPermitido))
            {
                base.OnActionExecuting(context);
                return;
            }

            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }
    }
}