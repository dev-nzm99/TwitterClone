
namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        public Guid CommentByUserId { get; set; }
        public CommentNotification(Guid commentByUserId):base("Comment") 
        {
           CommentByUserId = commentByUserId;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, CommentByUserId: {CommentByUserId}";
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
