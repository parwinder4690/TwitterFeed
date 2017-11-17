using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TwitterFeedAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TimeLineFeedController : ApiController
    {
        IFeedCacheManager feedCacheManager;
        public TimeLineFeedController(IFeedCacheManager _feedCacheManager)
        {
            feedCacheManager = _feedCacheManager;
        }

        [HttpGet]   
        public IHttpActionResult TimeLine()
        {
            
            var feedData = feedCacheManager.getFeedData();

            return Ok(feedData);
           
        }
    }
}
