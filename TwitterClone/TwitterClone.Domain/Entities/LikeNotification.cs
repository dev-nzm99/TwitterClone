
namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {
        public Guid LikeByUserId { get; set; }
        public LikeNotification(Guid likeByUserId) : base("Like")
        {
            LikeByUserId = likeByUserId;
        }
        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string GetMessage()
        {
            return $"User with id {LikeByUserId} liked your post.";
        }
    }
}
