using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testwebapi.Infrastructure;

namespace testwebapi.Controllers
{
    [Produces("application/json")]
    public class ErrorController : Controller
    {
        [Route("error/{code}")]
        public IActionResult HandleError(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}