
using System.Data;

namespace TwitterClone.Domain.Entities
{
    public class Retweet: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }
        public string Comment { get; set; }

        public Retweet(Guid userId, Guid tweetId):base(Guid.NewGuid())
        {
            UserId = userId;
            TweetId = tweetId;
        }

        public Retweet(Guid userId, Guid tweetId, string comment) : this(userId, tweetId)
        {
            Comment = comment;
        }
    }
}
