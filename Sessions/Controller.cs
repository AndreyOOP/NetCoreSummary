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

        // you can see that sessions on different browers are independant on each other
        [HttpGet("session")]
        public string SessionSample(SessionRequest request)
        {
            var currentSessionValue = HttpContext.Session.GetString(request.Key);
            
            HttpContext.Session.SetString(request.Key, request.Value);
            
            return $"Session value is '{currentSessionValue}'";
        }
    }

    // note that attributes could be used like below
    public class SessionRequest
    {
        [FromQuery]
        public string Key { get; set; }
        
        [FromQuery]
        public string Value { get; set; }
    }
}
