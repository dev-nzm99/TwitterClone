using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TwittersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TwittersController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }


        //GET api/twitters
        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = new List<object>{
                new
                {
                    UserId = Guid.NewGuid(),
                    Content = "This is my first tweet."
                },
                new
                {
                    UserId = Guid.NewGuid(),
                    Content = "This is my second tweet."
                }
            };
            return Ok(tweets);
        }
    }
}
