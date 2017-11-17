using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterFeedAPI.Models;

namespace TwitterFeedAPI.Tests
{
    class MockFeedProxy : ITwitterFeedProxy
    {
        public IList<FeedTweet> tweetList { get; set; }

        public IList<FeedTweet> GetUserFromScreenName(string userName, int maximumNumberOfTweets = 40)
        {
            return tweetList;
        }
    }
}
