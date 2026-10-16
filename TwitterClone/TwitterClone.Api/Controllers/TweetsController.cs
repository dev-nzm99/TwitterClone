using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders.Physical;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetServices _tweetServices;
        public TweetsController(ITweetServices tweetServices) 
        {
           _tweetServices = tweetServices;
        }


        [HttpPost]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            var createdTweet = _tweetServices.CreateTweet(createTweetDto);
        
            if(createdTweet == null)
            {
                return BadRequest($"User {createTweetDto.UserId} does not exists.");
            }

            return CreatedAtAction(nameof(GetTweetById),new { userId = createdTweet.Id}, createdTweet);
        }


        //GET api/tweets?userId={userId}
        [HttpGet]
        [ProducesResponseType(typeof(List<TweetDto>), StatusCodes.Status200OK)]
        public IActionResult GetTweets([FromQuery] Guid? userId)
        {
            return Ok(_tweetServices.GetTweets(userId));
        }


        //GET api/tweets/{userId}
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTweetById([FromRoute] Guid userId)
        {
            var tweet = _tweetServices.GetTweetById(userId);

            if(tweet  == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        //PUT api/tweets/{userId}
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTweet([FromRoute] Guid userId,[FromBody] UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetServices.UpdateTweet(userId, updateTweetDto);
            if(tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        //DELETE api/tweets/{userId}
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteTweet( [FromRoute] Guid userId )
        {
           var isDeleted = _tweetServices.DeleteTweet(userId);

           if(isDeleted == false)
            {
                return NotFound();
            }

           return NoContent();
        }
    }
}
