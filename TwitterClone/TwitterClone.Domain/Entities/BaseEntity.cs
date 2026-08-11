
namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? MoodifiedBy { get; set; }


        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
