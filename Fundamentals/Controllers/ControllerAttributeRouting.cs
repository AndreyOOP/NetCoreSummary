using Microsoft.AspNetCore.Mvc;

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
    }
}
