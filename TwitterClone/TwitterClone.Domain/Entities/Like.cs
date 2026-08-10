
namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        private Guid _userId { get; set; }
        private Guid _tweetId { get; set; }

        public Like(Guid userId, Guid tweetId):base(Guid.NewGuid())
        {
            _userId = userId;
            _tweetId = tweetId;
        }
    }
}
