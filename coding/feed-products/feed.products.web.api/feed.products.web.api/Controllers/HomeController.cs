using Microsoft.AspNetCore.Mvc;
using feed.products.application;
namespace feed_products.web.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IFeedApplication FeedApplication;
        public HomeController(IFeedApplication feedApplication)
        {
            FeedApplication = feedApplication;
        }
        // GET api/values
        [HttpPost]
        public ActionResult<bool> AddNewFeed(List<ThirdPartyDataModelDTOs> thirdPartyDataModelDTOs)
        {
            return FeedApplication.AddFeed(thirdPartyDataModelDTOs);
        }
        
    }
}
