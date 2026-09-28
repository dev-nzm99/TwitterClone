using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TwitterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void GetTweet()
        {
            var connectionString = _configuration.GetValue<string>("Logging:LogLevel:Default ");
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = new List<Tweet> 
            {
                new Tweet("My first tweet"){
                  UserId = Guid.NewGuid(),
                },
                new Tweet("My second tweet"){
                  UserId = Guid.NewGuid(),
                },
            };
            return Ok(tweets);
        }
    }
}
