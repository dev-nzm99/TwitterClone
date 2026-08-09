
using System.Data;

namespace TwitterClone.Domain.Entities
{
    public class Retweet
    {
        private Guid _userId;
        private Guid _tweetId;
        private DateTime _retweetAt;

        public Retweet(Guid userId, Guid tweetId)
        {
            _userId = userId;
            _tweetId = tweetId;
            _retweetAt = DateTime.Now;
        }

        public Guid UserId { get { return _userId; } }
        public Guid TweetsId { get { return _tweetId; } }
        public DateTime DateTime { get { return _retweetAt; } }
    }
}
