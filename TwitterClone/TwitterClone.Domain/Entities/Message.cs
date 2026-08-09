namespace TwitterClone.Domain.Entities
{
    public class Massage
    {
        private Guid _senderId { get; }
        private Guid _receiverId { get; }
        private string _content { get; }
        private DateTime _sendAt;
        private bool _isRead;

        public Massage(Guid senderId, Guid receiverId, string content, DateTime sendAt)
        {
            _senderId = senderId;
            _receiverId = receiverId;
            _content = content;
            _sendAt = DateTime.Now;
            _isRead = false;
        }
    }
}

