using Microsoft.AspNetCore.Mvc;
using System;

namespace Fundamentals.Controllers
{
    // route on action method will map all types (Get, Post etc) of the request
    [Route("routing-attributes")]
    public class ControllerAttributeRouting : ControllerBase
    {
        // Post request return - 405 Method Not Allowed
        [HttpGet("get-test")]
        public string GetTest()
        {
            return $"Controller {nameof(ControllerAttributeRouting)}, action {nameof(GetTest)} executed";
        }

        [Route("route-sample")]
        public string RouteSample()
        {
            return $"Controller {nameof(ControllerAttributeRouting)}, action {nameof(RouteSample)} executed. Method {HttpContext.Request.Method}";
        }

        [HttpGet("order-sample", Order = 2)]
        public string OrderSample1()
        {
            return "Order = 2";
        }

        [HttpGet("order-sample", Order = 1)] // lower order will be executed
        public string OrderSample2()
        {
            return "Order = 1";
        }

        [HttpGet("error/{i}")]
        public IActionResult ExceptionSample(int i)
        {
            if (i == 1)
                throw new ArgumentException();
            else if (i == 2)
                throw new Exception();

            // will return normally without exception reexecuting
            // if use application.UseStatusCodePages(); adds text message with status code description
            return StatusCode(401); 
        }
    }
}
