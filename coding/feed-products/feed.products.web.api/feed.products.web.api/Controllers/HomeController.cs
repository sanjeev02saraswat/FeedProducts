using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace feed_products.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/values
        [HttpPost]
        public ActionResult<IEnumerable<string>> AddNewFeed()
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}
