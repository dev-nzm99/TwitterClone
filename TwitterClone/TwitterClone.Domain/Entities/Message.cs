using System.Runtime.InteropServices;

namespace TwitterClone.Domain.Entities
{
    public class Massage : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public string Content { get; private set; }
        public bool IsRead { get; private set; }

        public Massage(Guid senderId, Guid receiverId, string content):base(Guid.NewGuid())
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            IsRead = false;
        }
    }
}

