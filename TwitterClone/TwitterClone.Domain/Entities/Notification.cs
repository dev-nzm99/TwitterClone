
namespace TwitterClone.Domain.Entities
{
    public abstract class Notification : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Type { get; set; }
        protected string? Message { get; set; }
        public bool IsRead { get; set; }

        public Notification(string type) : base(Guid.NewGuid())
        {
            Type = type;
        }
        public abstract string GetMessage();
    }
}
