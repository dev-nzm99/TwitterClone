
namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        private List<Guid> _followers = new List<Guid>();
        private List<Guid> _incomingNotifications = new List<Guid>();

        public User(string firstName, string lastName, string email) : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void Follow(Guid id)
        {
            if(!_followers.Contains(id))
            {
                _followers.Add(id);
            }
        }
        public void UnFollow(Guid id)
        {
            if (_followers.Contains(id))
            {
                _followers.Remove(id);
            }
        }

        public void AddNotification(Guid notificationId)
        {
            if (!_incomingNotifications.Contains(notificationId))
            {
                _incomingNotifications.Add(notificationId);
            }
        }
    }
}
