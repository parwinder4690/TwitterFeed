using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterFeedAPI.Models;


namespace TwitterFeedAPI
{
    //Cache component that cahche the data in memory
    public class FeedCacheManager : IFeedCacheManager
    {
        static IList<FeedTweet> data;

        public IList<FeedTweet> getFeedData()
        {
                return data;
        }

        public void setFeedData(IList<FeedTweet> feedList)
        {
                data = feedList;
        }
    }
}