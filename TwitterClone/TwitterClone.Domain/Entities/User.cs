
namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity
    {
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _email { get; }

        public User(string firstName, string lastName, string email) : base(Guid.NewGuid())
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }
    }
}
