
using System.Runtime.InteropServices;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark
    {
        private Guid _id { get; }
        private Guid _userId { get; }
        private Guid _tweetId { get; }
        private DateTime _createdAt { get; }
        
        public Bookmark( Guid userId, Guid tweetId)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _tweetId = tweetId;
            _createdAt = DateTime.Now;
        }
    }
}
