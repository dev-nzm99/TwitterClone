
using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class CreateTweetDto
    {
        public required Guid UserId { get; set; }
        [Required]
        public required string Content { get; set; }
    }
}
