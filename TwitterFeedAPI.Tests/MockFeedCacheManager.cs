using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterFeedAPI.Models;

namespace TwitterFeedAPI.Tests
{
    class MockFeedCacheManager : IFeedCacheManager
    {
        IList<FeedTweet> list;
        public IList<FeedTweet> getFeedData()
        {
            return list;
        }

        public void setFeedData(IList<FeedTweet> feedList)
        {
            list = feedList;
        }
    }
}
