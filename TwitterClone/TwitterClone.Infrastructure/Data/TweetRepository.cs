
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Data
{
    public class TweetRepository : ITweetRepository
    {
        private List<Tweet> _tweets = new List<Tweet>();

        public TweetRepository() { }

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            _tweets.RemoveAll(u => u.Id == tweet.Id);
            _tweets.Add(tweet);
            
            return tweet;
        }

        public List<Tweet>? GetTweets()
        {
           return _tweets.ToList();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(u => u.Id == id);
        }

        public int DelateTweetsByUserId(Guid userId)
        {
            return _tweets.RemoveAll(u =>u.UserId == userId);
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _tweets.Where(t => t.UserId == userId).ToList();
        }
    }
}
