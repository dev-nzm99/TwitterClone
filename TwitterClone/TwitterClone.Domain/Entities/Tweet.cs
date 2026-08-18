
namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikeable
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public static int MaxContentLength = 200;

        public Tweet(string content) : base(Guid.NewGuid())
        {
            Content = content;
        }

        public Tweet(Guid userId, string content) : this(content)
        {
            UserId = userId;
        }

        public bool CanBeLiked()
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                return false;
            }
            return true;
        }
    }
}
