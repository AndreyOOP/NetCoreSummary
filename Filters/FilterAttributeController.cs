using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    [Route("filter")]
    public class FilterAttributeController : ControllerBase
    {
        [HttpGet("attribute")]
        // at the response headers will be added TestHeader = Hello!
        [ResultFilterSample("TestHeader", "Hello!")] 
        public IActionResult TestFilterAttribute()
        {

            return Ok();
        }
    }

    public class ResultFilterSampleAttribute : ResultFilterAttribute
    {
        private string name;
        private string value;

        public ResultFilterSampleAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(name, new string[] { value });
            base.OnResultExecuting(context);
        }
    }
}
