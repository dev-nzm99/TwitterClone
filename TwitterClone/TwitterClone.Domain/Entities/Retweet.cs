
using System.Data;

namespace TwitterClone.Domain.Entities
{
    public class Retweet: BaseEntity
    {
        private Guid _userId { get; set; }
        private Guid _tweetId { get; set; }
        private string _comment { get; set; }

        //Comment Optional
        public Retweet(Guid userId, Guid tweetId, string? comment = null):base(Guid.NewGuid())
        {
            this._userId = userId;
            this._tweetId = tweetId;
            this._comment = comment;
        }

        //public Retweet(Guid userId, Guid tweetId, string comment) : this(userId, tweetId)
        //{
        //    _comment = comment;
        //}
    }
}
