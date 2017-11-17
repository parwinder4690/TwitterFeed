using System;
using System.Collections.Generic;
using TwitterFeedAPI.Models;

namespace TwitterFeedAPI
{
    public interface ITwitterFeedProxy
    {
        IList<FeedTweet> GetUserFromScreenName(String userName, int maximumNumberOfTweets = 40);
    }
}