using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundamentals.ErrorHandling
{
    [ApiController]
    //[Route("[controller]")]
    public class ErrorHandlerController : ControllerBase
    {
        [Route("/ErrorHandlerAction")]
        public void GetStatusCode()
        {
            
        }
    }
}
