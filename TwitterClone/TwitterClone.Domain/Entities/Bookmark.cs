
using System.Runtime.InteropServices;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }

        public Bookmark():base(Guid.NewGuid())
        {
            
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, UserId: {UserId}, TweetId: {TweetId}";
        }
    }
}
