using TwitterClone.Domain.Entities;

//var notification = new CommentNotification(Guid.NewGuid()) ;
//Console.WriteLine(notification.GetMessage());

var notifications = new List<Notification>  //Upcusting
{
    new LikeNotification(Guid.NewGuid()),
    new CommentNotification(Guid.NewGuid()),
    new FriendRequestNotification(Guid.NewGuid()),
    new MentionNotification(Guid.NewGuid()),
    new SystemNotification()
};

foreach (var notifiaction in notifications)
{
    Console.WriteLine(notifiaction.GetMessage());
    Console.WriteLine();
}

