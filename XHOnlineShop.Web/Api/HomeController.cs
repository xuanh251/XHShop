using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XHOnlineShop.Service;
using XHOnlineShop.Web.Infrastructure.Core;

namespace XHOnlineShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : APIControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            _errorService = errorService;
        }
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello world!";
        }

    }
}
