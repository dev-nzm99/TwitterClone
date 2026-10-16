
using System.Runtime.CompilerServices;
using TwitterClone.Application.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Mappings
{
    public static class MappingExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public static TweetDto ToDto(this Tweet tweet)
        {
            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content,
                CreateAt = tweet.CreatedAt,
                ModifiedAt = tweet.ModifiedAt,
            };
        }
    }
}
