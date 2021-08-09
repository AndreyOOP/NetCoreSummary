using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sessions
{
    [Route("sessions")]
    public class Controller : ControllerBase
    {
        [HttpGet("cookie")]
        public string CookieUpdate([FromQuery] string newValue)
        {
            // check cookie in request from client
            HttpContext.Request.Cookies.TryGetValue("cookie_key", out var cookieValue);

            // set cookie in response which will be received by browser
            HttpContext.Response.Cookies.Append("cookie_key", newValue);
            
            return $"Previous cookie value {cookieValue}, new cookie value {newValue}";
        }
    }
}
