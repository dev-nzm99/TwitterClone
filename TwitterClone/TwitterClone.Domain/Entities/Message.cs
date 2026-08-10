using System.Runtime.InteropServices;

namespace TwitterClone.Domain.Entities
{
    public class Massage : BaseEntity
    {
        private Guid _senderId { get; }
        private Guid _receiverId { get; }
        private string _content { get; }
        private bool _isRead { get; }

        public Massage(Guid senderId, Guid receiverId, string content):base(Guid.NewGuid())
        {
            this._senderId = senderId;
            this._receiverId = receiverId;
            this._content = content;
            this._isRead = false;
        }
    }
}

