
namespace TwitterClone.Domain.Entities
{
    public class MentionNotification : Notification
    {
        public Guid MentionedByUserId { get; set; }
        public MentionNotification(Guid mentionedByUserId) : base("Mention")
        {
            MentionedByUserId = mentionedByUserId;
        }
        public override string GetMessage()
        {
            return $"User with id {MentionedByUserId} mentioned you in post.";
        }
    }
}
