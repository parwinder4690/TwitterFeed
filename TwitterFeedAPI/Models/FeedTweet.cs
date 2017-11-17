using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterFeedAPI.Models
{
    public class FeedTweet
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string ScreenName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Text { get; set; }
        public int RetweetCount { get; set; }
        public DateTime CreatedAtxt { get; set; }
    }
}