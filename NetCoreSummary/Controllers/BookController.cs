using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSummary.Controllers
{
    [Route("api/[controller]")] // maps BooksController to api/books
    //[ApiController] // it is possible to use annotation but no access to Request etc
    public class BooksController : Controller
    {
        private readonly LinkGenerator linkGenerator;

        public BooksController(LinkGenerator linkGenerator) // injected from DI already registered implementation of LinkGenerator
        {
            this.linkGenerator = linkGenerator;
        }

        [HttpGet("action/{name}")] // complete route host/api/books/action/somename
        public async Task<IActionResult> Book(string name)
        {
            return new StatusCodeResult(200);
        }

        // Constraint & link generator sample
        [HttpGet("{flag:bool}")] // /api/books/true
        public async Task<IActionResult> Flag(bool flag)
        {
            var url = linkGenerator.GetPathByAction(Request.HttpContext); // /api/Books/true
            var url2 = linkGenerator.GetPathByAction( "Flag", "Books", new { flag = false }); // /api/Books/False

            return new StatusCodeResult(200);
        }
    }
}
