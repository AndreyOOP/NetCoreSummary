using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fundamentals.ErrorHandling
{
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        [Route("routing-attributes/ErrorHandlerAction")]
        public IActionResult ExceptionHandler()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (exceptionHandler.Error is ArgumentException)
                return Content($"Exception {nameof(ArgumentException)}");

            if (exceptionHandler.Error is Exception)
                return Content($"Exception {nameof(Exception)}");

            return StatusCode(200);
        }
    }
}
