
namespace TwitterClone.Domain.Entities
{
    public abstract class Notification : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Type { get; set; }
        protected string? Message { get; set; }
        public bool IsRead { get; set; }

        public Notification(string notificationType) : base(Guid.NewGuid())
        {
            Type = notificationType;
        }
        public abstract string GetMessage();

        public string GetNotificationInfo()
        {
            return $"UserId: {UserId}, NotificationType: {Type}";
        }
    }
}
