
namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        private Guid _followerId { get; set; }
        private Guid _followingId { get; set; }

        public Follow(Guid followerId, Guid followingId) : base(Guid.NewGuid())
        {
            this._followerId = followerId;
            this._followingId = followingId;
        }
    }
}
