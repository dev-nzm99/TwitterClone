
namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        private Guid _id { get; }
        private DateTime _createdAt { get; }
        private DateTime? _modifiedAt { get; set; }
        private Guid _createdBy { get; set; }
        private Guid? _modifiedBy { get; set; }


        public BaseEntity(Guid id)
        {
            _id = id;
            _createdAt = DateTime.UtcNow;
        }
    }
}
