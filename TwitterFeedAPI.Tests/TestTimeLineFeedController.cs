using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFeedAPI.Controllers;
using TwitterFeedAPI.Models;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace TwitterFeedAPI.Tests
{
    [TestClass]
    public class TestTimeLineFeedController
    {
        [TestMethod]
        public void GetTimeLine()
        {
            MockFeedCacheManager feedCacheManager = new MockFeedCacheManager();

            IList<FeedTweet> list = new List<FeedTweet>() {
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName" },
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName" }

                };
            feedCacheManager.setFeedData(list);

            var controller = new TimeLineFeedController(feedCacheManager);

            var result = controller.TimeLine() as OkNegotiatedContentResult<IList<FeedTweet>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count,2 );
        }
    }
}
