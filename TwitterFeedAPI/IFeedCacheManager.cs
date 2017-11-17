using System.Collections.Generic;
using TwitterFeedAPI.Models;


namespace TwitterFeedAPI
{
    public interface IFeedCacheManager
    {
        void setFeedData(IList<FeedTweet> feedList);
        IList<FeedTweet> getFeedData();
    }
}