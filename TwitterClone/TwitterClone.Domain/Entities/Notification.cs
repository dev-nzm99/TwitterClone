
namespace TwitterClone.Domain.Entities
{
    public class Notification : BaseEntity
    {
        private Guid _userId { get; }
        private string _type { get; set; }
        private string _message { get; set; }
        private bool _isRead { get; set; }

        public Notification(Guid userId,string message, string type):base(Guid.NewGuid())
        {
            this._userId = userId;
            this._message = message;
            this._type = type;
            this._isRead = false;
        }
    }
}
