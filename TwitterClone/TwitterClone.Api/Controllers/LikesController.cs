using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        public LikesController() { }

        //GET api/likes?userId={userId}&tweetId={tweetId} 
        [HttpGet]
        public IActionResult GetLikes ([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            return Ok(
               new List<object>
               {
                new
                 {
                     LikeId = Guid.NewGuid(),
                     UserId = userId ?? Guid.NewGuid(),
                     TweetId = tweetId ?? Guid.NewGuid(),
                     CreatedAt = DateTime.UtcNow.AddMinutes(-30),
                 },
                new
                {
                    LikeId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = tweetId ?? Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddMinutes(-10),
                }
               }
            );
        }


        [HttpGet("{id}")]
        public IActionResult GetLikedById([FromRoute] Guid id)
        {
            return Ok(new
            {
                LikeId = id,
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }


        [HttpPost]
        public IActionResult CreateLike()
        {
            return Ok(new
            {
                LikeId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLike([FromRoute] Guid id)
        {
            return Ok(new
            {
                LikeId = id,
                Message = "Like removed successfully.",
            });
        }
    }
}
