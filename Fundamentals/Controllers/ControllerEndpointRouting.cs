using Microsoft.AspNetCore.Mvc;

namespace Fundamentals.Controllers
{
    public class ControllerEndpointRouting : ControllerBase
    {
        public string SpecificAction(string id)
        {
            return $"Controller {nameof(ControllerEndpointRouting)}, action {nameof(SpecificAction)} executed. Id {id}";
        }

        public string Route(string id)
        {
            return $"Controller {nameof(ControllerEndpointRouting)}, action {nameof(Route)} executed";
        }

        // Get & Put method constraint
        [HttpGet]
        [HttpPut]
        public string TestRoute(string id)
        {
            return $"Controller {nameof(ControllerEndpointRouting)}, action {nameof(TestRoute)} executed";
        }
    }
}
