using TwitterClone.Application.Dtos;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;

        public TweetService(
            IUserRepository userRepository,
            ITweetRepository tweetRepository) 
        {
           _tweetRepository = tweetRepository;
           _userRepository = userRepository;
        }

        public TweetDto? CreateTweet(CreateTweetDto createTweetDto)
        {
            if (!IsValidContent(createTweetDto.Content))
            {
                return null;
            }

            var user = _userRepository.GetUserById(createTweetDto.UserId);
            
            if(user == null)
            {
                return null;
            }

            var createdtweet = _tweetRepository.AddTweet(
                new Tweet(user.Id, createTweetDto.Content));
            
            return createdtweet.ToDto();
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if( tweet == null)
            {
                return false;
            }

            return _tweetRepository.DeleteTweet(tweet);
        }

        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            return tweet?.ToDto();
        }

        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto)
        {
            if(!IsValidContent(updateTweetDto.Content))
            {
                return null;
            }

            var tweet = _tweetRepository.GetTweetById(id);
            if( tweet == null)
            {
                return null;
            }

            tweet.Content = updateTweetDto.Content.Trim();
            
            _tweetRepository.UpdateTweet(tweet);
            return tweet.ToDto();
        }

        private static bool IsValidContent(string content)
        {
            return !string.IsNullOrWhiteSpace(content) && content.Length <= Tweet.MaxContentLength; ;
        }

        public List<TweetDto> GetTweets(Guid? userId)
        {
            var tweets = userId.HasValue
                ? _tweetRepository.GetTweetsByUserId(userId.Value)
                : _tweetRepository.GetTweets();

            return tweets
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => t.ToDto())
                .ToList();
        }
    }
}
