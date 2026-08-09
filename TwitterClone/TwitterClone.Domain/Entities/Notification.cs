
namespace TwitterClone.Domain.Entities
{
    public class Notification
    {
        private Guid _id { get; }
        private Guid _userId { get; }
        private Guid _senderId { get; }
        private string _message{ get; }
        private DateTime _createdAt { get; }
        private bool _isRead { get; }

        public Notification(Guid userId, Guid senderId, string message)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _senderId = senderId;
            _message = message;
            _createdAt = DateTime.UtcNow;
            _isRead = false;
        }
    }
}
