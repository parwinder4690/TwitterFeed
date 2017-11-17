using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterFeedAPI.Models;

using System.Threading;

namespace TwitterFeedAPI
{
    //Feed Server take get the the timeLine every 1 mintue and store in the cache so clients and get the latest timeLine.
    public class FeederServer
    {
      
        private IFeedCacheManager feedCacheManager;
        private ITwitterFeedProxy feedProxy;

        public FeederServer(IFeedCacheManager _feedCacheManager, ITwitterFeedProxy _feedProxy)
        {
            feedCacheManager = _feedCacheManager;
            feedProxy = _feedProxy;
        }

        public void feedStart()
        {
            Thread thread = new Thread(feedProcess);
            thread.Start();
        }

        public  void feedProcess()
        {
            while (1 == 1)
            {
                IList<FeedTweet> feedList = feedProxy.GetUserFromScreenName("salesforce", 10); // it should be configurable

                feedCacheManager.setFeedData(feedList); // put data in cache

                Thread.Sleep(1000 * 60 );  // it should be configurable
            }

        }

    }
}