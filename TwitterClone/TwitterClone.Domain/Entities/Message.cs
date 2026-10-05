using System.Runtime.InteropServices;

namespace TwitterClone.Domain.Entities
{
    public class Massage : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public string Content { get; private set; }
        public bool IsRead { get; private set; }

        public Massage():base(Guid.NewGuid())
        {

        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, SenderId: {SenderId}, ReceiverId: {ReceiverId}, Content: {Content}, IsRead: {IsRead}";
        }
    }
}

