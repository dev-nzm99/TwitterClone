
namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        private Guid _userId { get; set; }
        private string _content { get; set; }

        public Tweet(Guid userId, string content) : base(Guid.NewGuid())
        {
            _userId = userId;
            _content = content;
        }
    }
}
