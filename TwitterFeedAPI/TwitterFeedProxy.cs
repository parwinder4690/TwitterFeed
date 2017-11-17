using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterFeedAPI.Models;

namespace TwitterFeedAPI
{
    //TwitterFeedProxy class will communicate with Twitter api and get the TimeLine
    public class TwitterFeedProxy : ITwitterFeedProxy
    {
        public IList<FeedTweet> GetUserFromScreenName(String userName, int maximumNumberOfTweets=40)
        {
            var user = User.GetUserFromScreenName(userName);

            var timelineTweets = user.GetUserTimeline(maximumNumberOfTweets);

            return convertToDTO(timelineTweets);
        }

        public IList<FeedTweet> convertToDTO(IEnumerable<ITweet> timelineTweets)
        {
            IList<FeedTweet> feedList = new List<FeedTweet>();

            foreach (ITweet tweet in timelineTweets)
            {
                FeedTweet feedTweet = new FeedTweet();

                var createdBY = tweet.CreatedBy;

                feedTweet.Id = tweet.Id;
                feedTweet.UserName = createdBY.Name;
                feedTweet.ScreenName = createdBY.ScreenName;
                feedTweet.ProfileImageUrl = createdBY.ProfileImageUrl;
                feedTweet.Text = tweet.FullText;
                feedTweet.RetweetCount = tweet.RetweetCount;
                feedTweet.CreatedAtxt = tweet.CreatedAt;

                feedList.Add(feedTweet);
            }

            return feedList;
        }
    }
}