
namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        public Guid CommentByUserId { get; set; }
        public CommentNotification(Guid commentByUserId):base("Comment") 
        {
           CommentByUserId = commentByUserId;
        }

        public void AddMessage(string message)
        {
            Message = message;
        }
        public override string GetMessage()
        {
            return $"User with id {CommentByUserId} comment on your post.";
        }
    }
}
