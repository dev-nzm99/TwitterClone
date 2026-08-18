
using System.Runtime.Intrinsics.X86;

namespace TwitterClone.Domain.Entities
{
    public interface IFollowable
    {
        void Follow(Guid userId);
        void UnFollow(Guid UserId);
    }
}
