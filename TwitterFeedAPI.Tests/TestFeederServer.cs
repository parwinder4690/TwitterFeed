using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TwitterFeedAPI.Models;
using System.Threading;

namespace TwitterFeedAPI.Tests
{
    [TestClass]
    public class TestFeederServer
    {
        [TestMethod]
        public void FeedUpdateAfterOneMintue()
        {
            MockFeedProxy feedProxy = new MockFeedProxy();  // Create mock object that have setter to set different values.
            IFeedCacheManager feedCacheManager = new FeedCacheManager();
            FeederServer feederServer = new FeederServer(feedCacheManager, feedProxy);

            IList<FeedTweet> tweetList = new List<FeedTweet>() {
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName 101" },
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName 102" }

                };

            feedProxy.tweetList = tweetList;
            feederServer.feedStart();
            Thread.Sleep(3000); // sleep few milliseconds to start FeedServer Thread.

            Assert.AreEqual(feedCacheManager.getFeedData().Count, 2);
            Assert.AreEqual(feedCacheManager.getFeedData()[0].ScreenName, "TestScreenName 101");

            //Create a new list
            IList<FeedTweet> tweetNewList = new List<FeedTweet>() {
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName 101 Updated" },
                                new FeedTweet() { Id = 101, ScreenName = "TestScreenName 102" }

                };

            feedProxy.tweetList = tweetNewList;
            Thread.Sleep(1000 * 60); // Sleep one mintue to update new feed
            Assert.AreEqual(feedCacheManager.getFeedData().Count, 2);
            Assert.AreEqual(feedCacheManager.getFeedData()[0].ScreenName, "TestScreenName 101 Updated");
        }
    }
}
