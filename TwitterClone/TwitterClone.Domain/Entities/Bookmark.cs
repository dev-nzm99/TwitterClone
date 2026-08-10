
using System.Runtime.InteropServices;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        private Guid _userId { get; }
        private Guid _tweetId { get; }

        public Bookmark(Guid userId, Guid tweetId):base(Guid.NewGuid())
        {
            _userId = userId;
            _tweetId = tweetId;
        }
    }
}
