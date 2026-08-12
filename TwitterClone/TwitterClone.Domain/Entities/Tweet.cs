
namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public Tweet(Guid userId, string content) : base(Guid.NewGuid())
        {
            UserId = userId;
            Content = content;
        }
    }
}
