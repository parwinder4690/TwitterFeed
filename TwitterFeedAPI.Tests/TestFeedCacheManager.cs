using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFeedAPI.Models;
using System.Collections.Generic;

namespace TwitterFeedAPI.Tests
{
    [TestClass]
    public class TestFeedCacheManager
    {
        [TestMethod]
        public void TestGetAndSetCache()
        {
            FeedCacheManager feedCacheManager = new FeedCacheManager();

            IList<FeedTweet> tweetList = new List<FeedTweet>() {
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName 101" },
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName 102" }

                };

            feedCacheManager.setFeedData(tweetList);

            Assert.AreEqual(feedCacheManager.getFeedData().Count, 2);
            Assert.AreEqual(feedCacheManager.getFeedData()[0].ScreenName, "TestScreenName 101");

        }
    }
}
