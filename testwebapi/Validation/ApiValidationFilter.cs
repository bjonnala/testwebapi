using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testwebapi.Infrastructure;

namespace testwebapi.Validation
{
    public class ApiValidationFilter : ActionFilterAttribute
    {
        // do something before the action executes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // check for valid apiKey: valid apiKey is ??92-road-DRAW-settle-99??
            var headers = context.HttpContext.Request.Headers;

            // if missing apiKey from headers. Then return unauthorized 401
            if (!headers.ContainsKey("apiKey"))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                foreach (var item in headers)
                {
                    if (item.Key == "apiKey")
                    {
                        if (item.Value.ToString().Trim() != "??92-road-DRAW-settle-99??")
                        {
                            context.Result = new UnauthorizedResult();
                        }

                    }

                }
            }
            

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
            }

            base.OnActionExecuting(context);
        }
    }
}
