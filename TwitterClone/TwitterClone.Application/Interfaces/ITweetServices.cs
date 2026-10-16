
using TwitterClone.Application.Dtos;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetServices
    {
        TweetDto? CreateTweet(CreateTweetDto creeetTweetDto);
        TweetDto? GetTweetById(Guid id);
        List<TweetDto> GetTweets(Guid? userId);
        TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto);
        bool DeleteTweet(Guid id);
    }
}
