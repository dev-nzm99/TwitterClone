
namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        private Guid _followerId;
        private Guid _followingId;
        private DateTime _followedAt;

        public Follow(Guid followerId)
        {
            _followerId = followerId;
            _followingId = Guid.NewGuid();
            _followedAt = DateTime.Now;
        }

        public Guid FolllowerId { get { return _followerId; } }
        public Guid FollowingId { get { return _followingId; } }
        public DateTime FollowedAt { get { return _followedAt; } }
    }
}
