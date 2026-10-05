using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders.Physical;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TweetsController : ControllerBase
    {
        public TweetsController() { }

        //GET api/tweets?userId={userId}
        [HttpGet]
        public IActionResult GetTweet([FromQuery] Guid? userId)
        {
            return Ok(
                new List<object>
                {
                    new
                    {
                        TweetId = Guid.NewGuid(),
                        UserId = userId ?? Guid.NewGuid(),
                        Content = "hello world!",
                        CreatedAt = DateTime.UtcNow.AddHours(-2)
                    },
                    new
                    {
                        TweetId = Guid.NewGuid(),
                        UserId = userId ?? Guid.NewGuid(),
                        Content = "This is my second tweet.",
                        CreatedAt = DateTime.UtcNow.AddHours(-1)
                    }
                }
            );
        }


        //GET api/tweets/{userId}
        [HttpGet("{userId}")]
        public IActionResult GetTweetById([FromRoute] Guid userId)
        {
            return Ok(
                new
                {
                    TweetId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Content = "tweet" + userId.ToString(),
                    CreatedAt = DateTime.UtcNow
                }
             );
        }


        [HttpPost]
        public IActionResult CreateTweet()
        {
            return Ok(
                new 
                {
                    TweetId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Content = "new tweet",
                    CreatedAt = DateTime.UtcNow
                }
             );
        }

        //PUT api/tweets/{userId}
        [HttpPut("{userId}")]
        public IActionResult UpdateTweet([FromRoute] Guid userId)
        {
            return Ok(
                new
                {
                    TweetId = userId,
                    UserId = Guid.NewGuid(),
                    Content = "update tweet" + userId.ToString(),
                    CreatedAt = DateTime.UtcNow
                }
             );
        }

        //DELETE api/tweets/{userId}
        [HttpDelete("{userId}")]
        public IActionResult DeleteTweet( [FromRoute] Guid userId )
        {
            return Ok(
                new
                {
                    TweetId = userId,
                    Massage = "Tweet deleted succesfully."
                }
             );
        }
    }
}
